using RedLoader;
using SUI;

namespace InventoryWeight
{
    public static class Config
    {
        public static ConfigCategory Category { get; private set; }

        public static ConfigEntry<bool> DebugMode { get; private set; }

        public static ConfigEntry<float> HeavyMeleeWeaponsWeight { get; private set; }
        public static ConfigEntry<float> LightMeleeWeaponsWeight { get; private set; }
        public static ConfigEntry<float> HeavyRangedWeaponsWeight { get; private set; }
        public static ConfigEntry<float> LightRangedWeaponsWeight { get; private set; }
        public static ConfigEntry<float> WeaponModsWeight { get; private set; }
        public static ConfigEntry<float> MaterialsWeight { get; private set; }
        public static ConfigEntry<float> FoodWeight { get; private set; }
        public static ConfigEntry<float> MedicineAndEnergyWeight { get; private set; }
        public static ConfigEntry<float> PlantsWeight { get; private set; }
        public static ConfigEntry<float> AmmunitionWeight { get; private set; }
        public static ConfigEntry<float> ThrowablesWeight { get; private set; }
        public static ConfigEntry<float> ExpendablesWeight { get; private set; }
        public static ConfigEntry<float> TransportWeight { get; private set; }

        public static ConfigEntry<float> MaxiumInventoryWeight { get; private set; }
        public static ConfigEntry<float> SpeedMultiplier { get; private set; }

        // Auto populated after calling SettingsRegistry.CreateSettings...
        private static SettingsRegistry.SettingsEntry _settingsEntry;

        public static void Init()
        {
            Category = ConfigSystem.CreateFileCategory("InventoryWeight", "InventoryWeight", "InventoryWeight.cfg");
            DebugMode = Category.CreateEntry("DebugModeID", true, "Debug", "Debug mode");

            HeavyMeleeWeaponsWeight = Category.CreateEntry<float>("HeavyMeleeWeaponsWeightID", 10, "Heavy Melee Weapons Weight", "Heavy Melee Weapons Weight");
            HeavyMeleeWeaponsWeight.SetRange(0, 50);
            LightMeleeWeaponsWeight = Category.CreateEntry<float>("LightMeleeWeaponsWeightID", 2, "Light Melee Weapons Weight", "Light Melee Weapons Weight");
            LightMeleeWeaponsWeight.SetRange(0, 50);
            HeavyRangedWeaponsWeight = Category.CreateEntry<float>("HeavyRangedWeaponsWeightID", 10, "Heavy Ranged Weapons Weight", "Heavy Ranged Weapons Weight");
            HeavyRangedWeaponsWeight.SetRange(0, 50);
            LightRangedWeaponsWeight = Category.CreateEntry<float>("LightRangedWeaponWeightID", 2, "Light Ranged Weapons Weight", "Light Ranged Weapons Weight");
            LightRangedWeaponsWeight.SetRange(0, 50);
            MaterialsWeight = Category.CreateEntry<float>("MaterialsWeightID", 2, "Materials Weight", "Materials Weight");
            MaterialsWeight.SetRange(0, 50);
            WeaponModsWeight = Category.CreateEntry<float>("WeaponModsWeightID", 2, "Weapon Mods Weight", "Weapon Mods Weight");
            WeaponModsWeight.SetRange(0, 50);
            FoodWeight = Category.CreateEntry<float>("FoodWeightID", 2, "Food Weight", "Food Weight");
            FoodWeight.SetRange(0, 50);
            MedicineAndEnergyWeight = Category.CreateEntry<float>("MedicineAndEnergyWeightID", 1, "Medicine And Energy Weight", "Medicine And Energy Weight");
            MedicineAndEnergyWeight.SetRange(0, 50);
            PlantsWeight = Category.CreateEntry<float>("PlantsWeightID", 0, "Plants Weight", "Plants Weight");
            PlantsWeight.SetRange(0, 50);
            AmmunitionWeight = Category.CreateEntry<float>("AmmunitionWeightID", 0, "Ammunition Weight", "Ammunition Weight");
            AmmunitionWeight.SetRange(0, 50);
            ThrowablesWeight = Category.CreateEntry<float>("ThrowablesWeightID", 0, "Throwables Weight", "Throwables Weight");
            ThrowablesWeight.SetRange(0, 50);
            ExpendablesWeight = Category.CreateEntry<float>("ExpendablesWeightID", 0, "Expendables Weight", "Expendables Weight");
            ExpendablesWeight.SetRange(0, 50);
            TransportWeight = Category.CreateEntry<float>("TransportWeightID", 0, "Transport Weight", "Transport Weight");
            TransportWeight.SetRange(0, 50);
            MaxiumInventoryWeight = Category.CreateEntry<float>("MaxiumInventoryWeightID", 65, "Maxium Inventory Weight", "Maxium Weight");
            MaxiumInventoryWeight.SetRange(0, 500);
            SpeedMultiplier = Category.CreateEntry<float>("SpeedMultiplierID", 2, "Speed Multiplier", "Speed Multiplier");
            SpeedMultiplier.SetRange(1, 10);
        }

        // Same as the callback in "CreateSettings". Called when the settings ui is closed.
        public static void OnSettingsUiClosed()
        {
        }
    }
}