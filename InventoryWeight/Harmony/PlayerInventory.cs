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
using static InventoryWeight.InventoryWeight;

namespace InventoryWeight.Harmony
{
    internal class PlayerInventory
    {
        [HarmonyPatch(typeof(TheForest.Items.Inventory.PlayerInventory), nameof(TheForest.Items.Inventory.PlayerInventory.AddItem))]
        private static class AddItem
        {
            private static void Prefix(int itemId, int amount = 1, bool preventAutoEquip = false, bool wasCrafted = false, ItemInstance itemInstance = null)
            {
                HandleNewItemInInventory(itemId, amount);
            }
        }
        [HarmonyPatch(typeof(TheForest.Items.Inventory.PlayerInventory), nameof(TheForest.Items.Inventory.PlayerInventory.RemoveItem))]
        private static class RemoveItem
        {
            private static void Prefix(int itemId, int amount = 1, bool allowAmountOverflow = false, bool shouldEquipPrevious = true, bool removeFromQuickSelect = true, ItemInstance itemInstance = null, bool instantDestroy = false)
            {
                HandleRemoveItemInInventory(itemId, amount);
            }
        }
    }
}
