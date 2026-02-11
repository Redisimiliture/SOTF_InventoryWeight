using RedLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWeight.Managers
{
    internal class DebugManager
    {
        public static void ConsoleLog(string message)
        {
            if (Config.DebugMode.Value)
            {
                RLog.Msg("[IW] " + message);
            }
        }

        public static void ConsoleLogWarning(string message)
        {
            if (Config.DebugMode.Value)
            {
                RLog.Warning("[IW] " + message);
            }
        }

        public static void ConsoleLogError(string message)
        {
            if (Config.DebugMode.Value)
            {
                RLog.Error("[IW] " + message);
            }
        }
    }
}
