using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectPluginHost
{
    /// <summary>
    /// Enumeration of the statuses for the plugins.
    /// </summary>
    public enum PluginStatus
    {
        Undefined,
        Active,
        Disabled,
        DisabledDueToException
    }

}
