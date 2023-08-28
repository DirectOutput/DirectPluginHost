using DirectPluginInterface;

/// <summary>
/// Namespace for the plugin hosting implementation.
/// </summary>
namespace DirectPluginHost
{
    /// <summary>
    /// This is the main class of the plugin system. It is also the only class which has to be instaciated to make the plugin system work.<br/>
    /// It loads the plugins when the class is instanciated and provides the necessary methods to communicate with the plugins.
    /// </summary>
    public class Host
    {

        private HostStatus _Status = HostStatus.New;

        /// <summary>
        /// Gets or sets the status of the plugin host.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public HostStatus Status
        {
            get { return _Status; }
        }

        private PluginList _Plugins = new PluginList();

        /// <summary>
        /// Gets the list of plugins.
        /// </summary>
        /// <value>
        /// The list of plugins.
        /// </value>
        public PluginList Plugins
        {
            get { return _Plugins; }

        }


        /// <summary>
        /// Initializes all loaded plugins.<br/>
        /// This is the first method which has to be called, after the Host class has been instanciated.
        /// </summary>
        /// <param name="HostingApplicationName">Name of the hosting application.</param>
        /// <param name="TableFilename">The table filename.<br>If no table filename is available, it is best to provide a path and name of a non existing dummy file, since the plugins might use this path to identify the directories where the store logs, load config from an so on.</br></param>
        /// <param name="GameName">Name of the game.<br/>If the game is a SS pinball table it is highly recommanded to provide the name of the game rom, otherwise any other name which identifiey to game uniquely will be fine as well.</param>
        public void PluginsInit(string HostingApplicationName, string TableFilename, string GameName)
        {
            if (_Status != HostStatus.Initialized)
            {
                foreach (Plugin Plugin in Plugins)
                {
                    Plugin.PluginInit(HostingApplicationName, TableFilename, GameName);
                }
                _Status = HostStatus.Initialized;
            }
        }

        /// <summary>
        /// Finishes all loaded plugins.<br/>
        /// This is the last method which has to be called on the Host class before the hosting application is shut down or before the Host class gets discarded.<br/>
        /// Plugins can be reinitialized by call PluginsInits, after they have been finished using this method.
        /// </summary>
        public void PluginsFinish()
        {
            if (_Status == HostStatus.Initialized)
            {
                foreach (Plugin Plugin in Plugins)
                {
                    Plugin.PluginFinish();
                }
                _Status = HostStatus.Finished;
            }
        }


        /// <summary>
        /// Calls the DataReceive method on all loaded plugins.<br/>
        /// This method has to be called for every state change of a table element (e.g. solenoid, switch) in the pinball simulation.        
        /// </summary>
        /// <param name="TableElementTypeChar">Char identifying the type of the table element. S=Solenoid, W=Switch, L=Lamp, E=EMTable element, but other values are supported as well. For a full list, please check description on the TableElementTypeEnum in the DirectOutput framework.</param>
        /// <param name="Number">The number of the table element which has changed.</param>
        /// <param name="Value">The new value/state of the table element.</param>
        public void PluginsDataReceive(char TableElementTypeChar, int Number, int Value)
        {
            if (_Status == HostStatus.Initialized)
            {
                foreach (Plugin Plugin in Plugins)
                {
                    Plugin.PluginDataReceive(TableElementTypeChar, Number, Value);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Host"/> class.
        /// </summary>
        public Host()
        {
            _Plugins = new PluginList(true);
        }

    }
}
