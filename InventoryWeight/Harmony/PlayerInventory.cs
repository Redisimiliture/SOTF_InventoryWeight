using HarmonyLib;
using InventoryWeight.Managers;
using RedLoader;
using Sons.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TheForest.Items.Inventory;
using TheForest.Utils;
using static InventoryWeight.Managers.GameManager;
using static InventoryWeight.Managers.WeightManager;

namespace InventoryWeight.Harmony
{
    internal class PlayerInventory
    {
        [HarmonyPatch(typeof(TheForest.Items.Inventory.PlayerInventory), nameof(TheForest.Items.Inventory.PlayerInventory.AddItem))]
        private static class AddItem
        {
            private static void Prefix(int itemId, int amount = 1, bool preventAutoEquip = false, bool wasCrafted = false, ItemInstance itemInstance = null)
            {
                HandleAddedItemToInventory(itemId, amount);
            }
        }
        [HarmonyPatch(typeof(TheForest.Items.Inventory.PlayerInventory), nameof(TheForest.Items.Inventory.PlayerInventory.RemoveItem))]
        private static class RemoveItem
        {
            private static void Prefix(int itemId, int amount = 1, bool allowAmountOverflow = false, bool shouldEquipPrevious = true, bool removeFromQuickSelect = true, ItemInstance itemInstance = null, bool instantDestroy = false)
            {
                HandleRemovedItemFromInventory(itemId, amount);
            }
        }
        public static void HandleAddedItemToInventory(int itemId, int amount)
        {
            DebugManager.ConsoleLog($"ItemID: {itemId}");
            DebugManager.ConsoleLog($"Amount: {amount}");
            if (LocalPlayer.Inventory == null) { return; }
            DebugManager.ConsoleLog($"LocalPlayer.Inventory: {LocalPlayer.Inventory}");
            if (LocalPlayer.Inventory.GetAvailableSpaceForItem(itemId) >= amount)
            {
                PlayerInventoryItems ??= new Dictionary<int, int>();

                if (PlayerInventoryItems.ContainsKey(itemId)) { PlayerInventoryItems[itemId] += amount; }
                else { PlayerInventoryItems.Add(itemId, amount); }
                PlayerInventoryWeight += CalculateItemWeight(itemId, amount);

                DebugManager.ConsoleLog($"Added {amount} {itemId}");

                WeightUpdate();
            }
        }

        public static void HandleRemovedItemFromInventory(int itemId, int amount)
        {
            PlayerInventoryItems ??= new Dictionary<int, int>();

            if (amount > 1) { PlayerInventoryItems[itemId] -= amount; }
            else { PlayerInventoryItems.Remove(itemId); }

            PlayerInventoryWeight -= CalculateItemWeight(itemId, amount);

            DebugManager.ConsoleLog($"Removed {amount} {itemId}");
            WeightUpdate();
        }
    }
}

