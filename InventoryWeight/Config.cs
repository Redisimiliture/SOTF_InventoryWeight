using RedLoader;
using SUI;

namespace InventoryWeight
{
    public static class Config
    {
        public static ConfigCategory Category { get; private set; }

        public static ConfigEntry<bool> DebugMode { get; private set; }

        // Auto populated after calling SettingsRegistry.CreateSettings...
        private static SettingsRegistry.SettingsEntry _settingsEntry;

        public static void Init()
        {
            Category = ConfigSystem.CreateFileCategory("InventoryWeight", "InventoryWeight", "InventoryWeight.cfg");
            DebugMode = Category.CreateEntry("DebugModeID", true, "Debug", "Debug mode");
        }

        // Same as the callback in "CreateSettings". Called when the settings ui is closed.
        public static void OnSettingsUiClosed()
        {
        }
    }
}