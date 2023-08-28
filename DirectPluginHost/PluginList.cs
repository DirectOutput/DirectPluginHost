using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using DirectPluginInterface;

namespace DirectPluginHost
{
    /// <summary>
    /// List of Plugin objects. <br/>
    /// Used by the PluginHost class.
    /// </summary>
    public class PluginList : List<Plugin>
    {

        /// <summary>
        /// Loads the plugins from the plugins directory.<br/>
        /// The plugins directory must be a subdirectory of the directory containing the hosting application. This directory can contain any number of subdirectories containing plugins and any number of shortcuts pointing to directories containing plugins.<br/>
        /// Plugins in subdirectories or shortcuts having a name start with "-" are not loaded.<br/>
        /// Plugins must be class libraries implementing the IDirectPlugin interface found in the PluginInterface.dll and must export this type for composition (see MEF docu for more info).
        /// </summary>
        public void LoadPlugins()
        {
            //Clear the list of previously loaded plugins
            this.Clear();

            List<string> LoadedDirectories = new List<string>();

            try
            {
                //Get the path of the currently executed application
                DirectoryInfo AssemblyDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                //Look for the plugin or plugins folder
                foreach (DirectoryInfo PluginDirectory in AssemblyDirectory.GetDirectories())
                {
                    if (PluginDirectory.Name.ToLower() == "plugin" || PluginDirectory.Name.ToLower() == "plugins")
                    {
                        //Scan for subdirectories containing plugins
                        foreach (DirectoryInfo PluginSubDirectory in PluginDirectory.GetDirectories())
                        {
                            if (!PluginSubDirectory.Name.StartsWith("-"))
                            {
                                if (!LoadedDirectories.Contains(PluginSubDirectory.FullName.ToLower()))
                                {
                                    LoadDirectoryPlugins(PluginSubDirectory);
                                    LoadedDirectories.Add(PluginSubDirectory.FullName.ToLower());
                                }

                            }
                        }


                        //Check plugin directory for shortcuts (.lnk files) and load plugins if shortcut points to a directory
                        //Code is using the WScriptShell com object to resolve the shortcuts. Late binding is used to avoid versioning issues.
                        Type WScriptShellType;
                        dynamic WScriptShell = null;
                        try
                        {
                            WScriptShellType = System.Type.GetTypeFromProgID("WScript.Shell");
                            WScriptShell = System.Activator.CreateInstance(WScriptShellType);
                        }
                        catch
                        {
                        }

                        if (WScriptShell != null)
                        {
                            try
                            {
                                foreach (FileInfo LnkFile in PluginDirectory.GetFiles("*.lnk"))
                                {
                                    if (!LnkFile.Name.StartsWith("-"))
                                    {

                                        try
                                        {
                                            dynamic Shortcut = WScriptShell.CreateShortcut(LnkFile.FullName);
                                            string TargetPath = Shortcut.TargetPath;

                                            if (Directory.Exists(TargetPath))
                                            {
                                                //It's a folder path

                                                DirectoryInfo LnkDirectory = new DirectoryInfo(TargetPath);
                                                //Skip if directory has already been loaded
                                                if (!LoadedDirectories.Contains(LnkDirectory.FullName.ToLower()))
                                                {
                                                    LoadDirectoryPlugins(LnkDirectory);
                                                    LoadedDirectories.Add(LnkDirectory.FullName.ToLower());
                                                }
                                            }

                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }

                        break;
                    }
                }

            }
            catch
            {
            }
        }

        /// <summary>
        /// MEF puts the plugins it imports into this list. From here the plugins are added to the plugin list.
        /// </summary>
        [ImportMany(typeof(IDirectPlugin))]
        private IEnumerable<IDirectPlugin> ImportedPlugins;

        /// <summary>
        /// Loads the plugins in a specific directory
        /// </summary>
        /// <param name="Directory">The directory containing the plugins.</param>
        private void LoadDirectoryPlugins(DirectoryInfo Directory)
        {
            ImportedPlugins = new List<IDirectPlugin>();

            try
            {
                DirectoryCatalog Catalog = new DirectoryCatalog(Directory.FullName);
                CompositionContainer Container = new CompositionContainer(Catalog);

                Container.ComposeParts(this);
            }
            catch
            {
            }

            if (ImportedPlugins != null)
            {
                AddRange(ImportedPlugins);
            }
            ImportedPlugins = null;
        }

        /// <summary>
        /// Adds a range of IDirectPlugin objectes to the list.
        /// </summary>
        /// <param name="Plugins">The IDirectPlugin plugin instances.</param>
        private void AddRange(IEnumerable<IDirectPlugin> Plugins)
        {
            foreach (IDirectPlugin P in Plugins)
            {
                Add(new Plugin() { PluginInstance = P });
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PluginList"/> class.
        /// </summary>
        /// <param name="LoadPlugins">if set to <c>true</c> the plugins are loaded upon instanciation of this class.</param>
        public PluginList(bool LoadPlugins = false)
        {
            if (LoadPlugins)
            {
                this.LoadPlugins();
            }
        }

    }
}
