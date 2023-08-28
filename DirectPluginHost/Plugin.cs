using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectPluginInterface;

namespace DirectPluginHost
{
    /// <summary>
    /// This class handles a instance of a IDirectPlugin object.<br/>
    /// It provides the calls to the plugin methods and ensures that all exceptions which are eventually not handled by the plugin, are catched and handled. If a IDirectPlugin object throws a exception it gets deactivated.
    /// </summary>
    public class Plugin
    {
        private IDirectPlugin _PluginInstance;

        /// <summary>
        /// Gets or sets the instance of the plugin.
        /// </summary>
        /// <value>
        /// The plugin instance.
        /// </value>
        public IDirectPlugin PluginInstance
        {
            get { return _PluginInstance; }
            set
            {
                _PluginInstance = value;
                if (value != null)
                {
                    Status = PluginStatus.Active;
                }
                else
                {
                    Status = PluginStatus.Undefined;
                }
            }
        }


        private PluginStatus _Status = PluginStatus.Active;

        /// <summary>
        /// Gets the status of the IDirectPlugin object.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public PluginStatus Status
        {
            get { return _Status; }
            private set { _Status = value; }
        }


        /// <summary>
        /// Gets the name of the IDirectPlugin object.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                try
                {
                    if (PluginInstance != null)
                    {
                        return PluginInstance.Name;
                    }
                }
                catch (Exception Ex)
                {
                    HandlePluginException(Ex);

                };
                return "<Name cant be queried>";
            }
        }

        private Exception _LastException;

        /// <summary>
        /// Gets the last exception which has occured in the IDirectPlugin object handled by the class instance.
        /// </summary>
        /// <value>
        /// The last exception.
        /// </value>
        public Exception LastException
        {
            get { return _LastException; }
            private set { _LastException = value; }
        }


        /// <summary>
        /// Initializes the IDirectPlugin object handled by this class.<br/>
        /// This is the first method which has to be called by the hosting application.
        /// </summary>
        /// <param name="HostingApplicationName">Name of the hosting application.</param>
        /// <param name="TableFilename">The table filename.<br>If no table filename is available, it is best to provide a path and name of a non existing dummy file, since the plugins might use this path to identify the directories where the store logs, load config from an so on.</br></param>
        /// <param name="GameName">Name of the game.<br/>If the game is a SS pinball table it is highly recommanded to provide the name of the game rom, otherwise any other name which identifiey to game uniquely will be fine as well.</param>
        public void PluginInit(string HostingApplicationName, string TableFilename, string GameName)
        {
            if (Status == PluginStatus.Active)
            {
                try
                {
                    PluginInstance.PluginInit(HostingApplicationName, TableFilename, GameName);
                }
                catch (Exception Ex)
                {
                    HandlePluginException(Ex);
                }
            }
        }


        /// <summary>
        /// Finishes the IDirectPlugin object handled by this class.
        /// </summary>
        public void PluginFinish()
        {
            if (Status == PluginStatus.Active)
            {
                try
                {
                    PluginInstance.PluginFinish();
                }
                catch 
                {
                    Status = PluginStatus.DisabledDueToException;
                }
            }
        }

        /// <summary>
        /// Calls DataReceive on the IDirectPlugin object handled by this class.<br/>
        /// </summary>
        /// <param name="TableElementTypeChar">Char identifying the type of the table element. S=Solenoid, W=Switch, L=Lamp, E=EMTable element, but other values are supported as well. For a full list, please check description on the TableElementTypeEnum in the DirectOutput framework.</param>
        /// <param name="Number">The number of the table element which has changed.</param>
        /// <param name="Value">The new value/state of the table element.</param>
        public void PluginDataReceive(char TableElementTypeChar, int Number, int Value)
        {
            if (Status == PluginStatus.Active)
            {
                try
                {
                    PluginInstance.DataReceive(TableElementTypeChar, Number, Value);
                }
                catch (Exception Ex)
                {
                    HandlePluginException(Ex);
                }
            }
        }




        /// <summary>
        /// Handles exceptions which are thrown by the IDirectPlugin object handled by this class.<br/>
        /// On exceptions it deactivates the plugin and tries to call the Finish method.
        /// </summary>
        /// <param name="PluginException">The plugin exception.</param>
        private void HandlePluginException(Exception PluginException)
        {
            LastException = PluginException;

            try
            {
                PluginInstance.PluginFinish();
            }
            catch
            {
            }

            Status = PluginStatus.DisabledDueToException;
        }



    }
}
