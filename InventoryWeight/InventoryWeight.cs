using HarmonyLib;
using Il2CppInterop.Runtime.Attributes;
using Il2CppSystem.IO;
using InventoryWeight.Managers;
using Microsoft.VisualBasic;
using RedLoader;
using Sons.Gameplay.Achievements;
using Sons.Inventory;
using SonsSdk;
using SUI;
using System.Text.Json;
using TheForest.Items.Inventory;
using TheForest.Utils;
using UnityEngine.Playables;
using UnityEngine.UI;
using static InventoryWeight.InventoryWeight;
using static InventoryWeight.Managers.GameManager;
using static InventoryWeight.Managers.WeightManager;

namespace InventoryWeight
{
    public class InventoryWeight : SonsMod
    {

        public InventoryWeight()
        {
            HarmonyPatchAll = true;
        }

        protected override void OnInitializeMod()
        {
            Config.Init();
        }

        protected override void OnSdkInitialized()
        {
            InventoryWeightUi.Create();

            SettingsRegistry.CreateSettings(this, null, typeof(Config));

        }

        protected override void OnGameStart()
        {
            PlayerInventory Inventory = LocalPlayer.Inventory;
            BuildItemIdWeights();

            PlayerInventoryItems = GetAllItemsInInventory(Inventory);
            PlayerInventoryWeight = CalculateInventoryWeight(PlayerInventoryItems);

            WeightUpdate();

            if (Config.DebugMode.Value == true)
            {
                Dictionary<int, int> ItemsInInventory = GetAllItemsInInventory(Inventory);

                foreach (KeyValuePair<int, int> ItemIdAndAmount in PlayerInventoryItems)
                {
                    string _debugtestvariable1 = (ItemIdAndAmount.Value > 1) ? "they weight" : "it weights";
                    RLog.Msg($"[IW] LocalPlayer has: {ItemIdAndAmount.Value} {ItemIdAndAmount.Key} in inventory");
                }
            } 
        }
    }
}        

