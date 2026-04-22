using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Utils;
using static InventoryWeight.InventoryWeight;
using static InventoryWeight.Managers.GameManager;

namespace InventoryWeight.Managers
{
    internal class WeightManager
    {
        public static Dictionary<int, float> ItemIdToWeight { get; set; } = new Dictionary<int, float>();
        public static float PlayerInventoryWeight { get; set; }

        public static float CalculateItemWeight(int itemId, int amount, Dictionary<int, float> itemIdtoWeight = null)
        {
            itemIdtoWeight ??= ItemIdToWeight;

            if (itemIdtoWeight.ContainsKey(itemId)) { return itemIdtoWeight[itemId] * amount; }

            return 0;
        }

        public static float CalculateInventoryWeight(Dictionary<int, int> inventory)
        {
            ArgumentNullException.ThrowIfNull(inventory);

            float Weight = 0;

            foreach (KeyValuePair<int, int> ItemIdAndAmount in inventory) { Weight += CalculateItemWeight(ItemIdAndAmount.Key, ItemIdAndAmount.Value); }

            return Weight;
        }

        public static void BuildItemIdWeights(int[] itemIdArray = null)
        {
            itemIdArray ??= AllitemIdArray;

            float LightMeleeWeaponsWeight = Config.LightMeleeWeaponsWeight.Value;
            float HeavyMeleeWeaponsWeight = Config.HeavyMeleeWeaponsWeight.Value;
            float LightRangedWeaponsWeight = Config.LightMeleeWeaponsWeight.Value;
            float HeavyRangedWeaponsWeight = Config.HeavyMeleeWeaponsWeight.Value;
            float WeaponModsWeight = Config.WeaponModsWeight.Value;
            float HeavyMaterialsWeight = Config.HeavyMaterialsWeight.Value;
            float LightMaterialsWeight = Config.LightMaterialsWeight.Value;
            float VeryLightMaterialsWeight = Config.VeryLightMaterialsWeight.Value;
            float FoodWeight = Config.FoodWeight.Value;
            float MedicineAndEnergyWeight = Config.MedicineAndEnergyWeight.Value;
            float PlantsWeight = Config.PlantsWeight.Value;
            float AmmunitionWeight = Config.AmmunitionWeight.Value;
            float ThrowablesWeight = Config.ThrowablesWeight.Value;
            float ExpendablesWeight = Config.ExpendablesWeight.Value;
            float TransportWeight = Config.TransportWeight.Value;

            Dictionary<int, float> itemIdWeights = new Dictionary<int, float>();

            foreach (int itemId in itemIdArray)
            {
                if (ItemIdsLightMeleeWeapons.Contains(itemId)) { itemIdWeights.Add(itemId, LightMeleeWeaponsWeight); continue; }
                if (ItemIdsHeavyMeleeWeapons.Contains(itemId)) { itemIdWeights.Add(itemId, HeavyMeleeWeaponsWeight); continue; }
                if (ItemIdsHeavyRangedWeapons.Contains(itemId)) { itemIdWeights.Add(itemId, HeavyRangedWeaponsWeight); continue; }
                if (ItemIdsLightRangedWeapons.Contains(itemId)) { itemIdWeights.Add(itemId, LightRangedWeaponsWeight); continue; }
                if (ItemIdsWeaponMods.Contains(itemId)) { itemIdWeights.Add(itemId, WeaponModsWeight); continue; }
                if (ItemIdsHeavyMaterials.Contains(itemId)) { itemIdWeights.Add(itemId, HeavyMaterialsWeight); continue; }
                if (ItemIdsLightMaterials.Contains(itemId)) { itemIdWeights.Add(itemId, LightMaterialsWeight); continue; }
                if (ItemIdsVeryLightMaterials.Contains(itemId)) { itemIdWeights.Add(itemId, VeryLightMaterialsWeight); continue; }
                if (ItemIdsFood.Contains(itemId)) { itemIdWeights.Add(itemId, FoodWeight); continue; }
                if (ItemIdsMedicineAndEnergy.Contains(itemId)) { itemIdWeights.Add(itemId, MedicineAndEnergyWeight); continue; }
                if (ItemIdsPlants.Contains(itemId)) { itemIdWeights.Add(itemId, PlantsWeight); continue; }
                if (ItemIdsAmmunition.Contains(itemId)) { itemIdWeights.Add(itemId, AmmunitionWeight); continue; }
                if (ItemIdsThrowables.Contains(itemId)) { itemIdWeights.Add(itemId, ThrowablesWeight); continue; }
                if (ItemIdsExpendables.Contains(itemId)) { itemIdWeights.Add(itemId, ExpendablesWeight); continue; }
                if (ItemIdsTransport.Contains(itemId)) { itemIdWeights.Add(itemId, TransportWeight); continue; }
            }

            ItemIdToWeight = itemIdWeights;
        }


        public static void WeightUpdate()
        {
            LocalPlayer.FpCharacter.SetRunSpeed(Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_RunSpeed);
            DebugManager.ConsoleLog($"Player Run Speed: {Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_RunSpeed}");
            LocalPlayer.FpCharacter.SetWalkSpeed(Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_WalkSpeed);
            DebugManager.ConsoleLog($"Player Walk Speed: {Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_WalkSpeed}");
            LocalPlayer.FpCharacter.SetSwimSpeed(Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_SwimSpeed);
            DebugManager.ConsoleLog($"Player Swim Speed: {Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_SwimSpeed}");
            LocalPlayer.FpCharacter._crouchSpeed = Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_CrouchSpeed;
            DebugManager.ConsoleLog($"Player Crouch Speed: {Math.Max(0, 1 - (PlayerInventoryWeight - Config.DefaultInventoryWeight.Value) / Config.MaxiumInventoryWeight.Value) * Config.SpeedMultiplier.Value * d_CrouchSpeed}");
            DebugManager.ConsoleLog($"Player Weight: {PlayerInventoryWeight}");
        }
    }
}
