using HarmonyLib;
using RedLoader;
using Sons.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TheForest.Items.Inventory;

namespace InventoryWeight.Harmony
{
    internal class PlayerInventory
    {
        [HarmonyPatch(typeof(TheForest.Items.Inventory.PlayerInventory), nameof(TheForest.Items.Inventory.PlayerInventory.AddItem))]
        private static class AddItem
        {
            private static void Prefix(int itemId, int amount = 1, bool preventAutoEquip = false, bool wasCrafted = false, ItemInstance itemInstance = null)
            {
                InventoryWeight.HandleNewItemInInventory(itemId, amount);
            }
        }
    }
}

