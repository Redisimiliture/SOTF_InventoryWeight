using HarmonyLib;
using Il2CppInterop.Runtime.Attributes;
using Microsoft.VisualBasic;
using RedLoader;
using Sons.Gameplay.Achievements;
using Sons.Inventory;
using SonsSdk;
using SUI;
using TheForest.Items.Inventory;
using TheForest.Utils;

namespace InventoryWeight
{
    public class InventoryWeight : SonsMod
    {
        private static int[] _AllItemIDArray = { 340, 356, 359, 367, 379, 394, 396, 431, 474, 477, 503, 525, 663, 358, 360, 361, 386, 443, 459, 353, 365, 355, 422, 522, 485, 362, 363, 364, 369, 387, 370, 153, 711, 537, 215, 457, 125, 073, 736, 183, 683, 665, 244, 765, 233, 813, 884, 174, 403, 463, 743, 753, 763, 784, 735, 194, 945, 935, 545, 727, 274, 874, 904, 914, 924, 934, 954, 995, 006, 397, 037, 495, 555, 565, 575, 586, 194, 014, 214, 254, 334, 344, 364, 384, 414, 644, 664, 804, 815, 695, 705, 714, 374, 394, 554, 564, 614, 623, 973, 983, 994, 004, 454, 464, 474, 484, 495, 945, 954, 504, 514, 524, 534, 544, 655, 965, 975, 985, 996, 006, 016, 026, 036, 046, 056, 067, 839, 540, 628, 408, 409, 685, 761, 857, 728, 578, 385, 045, 066, 406, 346, 353, 923, 934, 034, 054, 104, 144, 154, 164, 184, 194, 204, 430, 479, 484, 496, 502, 527, 553, 560, 657, 366, 166, 452, 152, 652, 853, 415, 352, 536, 353, 745, 385, 395, 405, 415, 421, 543, 215, 442, 254, 554, 654, 754, 861, 161, 261, 361, 461, 516, 166, 176, 531, 654, 265, 536, 746, 756, 766, 776, 786, 846, 856, 866, 876, 916, 926, 936, 946, 951, 696, 269, 736, 997, 067, 177, 167, 207, 216, 906, 315, 745, 754, 231, 042, 410, 509, 633, 705, 467, 627, 628, 665, 666, 670, 671, 672, 679, 680, 681, 682, 688, 701, 709, 710, 711, 714, 726, 662, 166, 726, 683, 669, 468, 957, 086, 712, 770, 748, 264, 264, 364, 464, 664, 764, 865, 065, 165, 271, 556, 656, 756, 863, 738, 040, 241, 241, 348, 348, 658, 944, 434, 135, 439, 143, 542, 642, 843, 246, 847, 151, 752, 959, 062, 663, 039, 046, 950, 837, 738, 238, 338, 948, 952, };
        public static Dictionary<int, int> _ItemIDWeights { get; set; }
        public class ItemsInPlayerInventory : ICustomSaveable<ItemIDAndAmount>
        {
            public string Name => "ItemsInPlayerInventory";

            public bool IncludeInPlayerSave => true;

            public ItemIDAndAmount Save()
            {
                // Serialize your data from game state here
                var ItemsInPlayerInventory = new ItemIDAndAmount();
                return ItemsInPlayerInventory;
            }

            public void Load(ItemIDAndAmount obj)
            {
                // Apply game state from your data here
            }

        }
        public class ItemIDAndAmount
        {
            public List<int> ItemID { get; set; }
            public List<int> Amount { get; set; }
        }

        public static ItemIDAndAmount GetAllItemInInventory(PlayerInventory Inventory, int[] ItemIDArray = null)
        {
            ItemIDArray ??= _AllItemIDArray;

            ArgumentNullException.ThrowIfNull(Inventory);

            ItemIDAndAmount _ItemsInPlayerInventory = new();
            _ItemsInPlayerInventory.ItemID = new();
            _ItemsInPlayerInventory.Amount = new();

            foreach (int ItemID in ItemIDArray)
            {
                if (Inventory.AmountOf(ItemID) != 0)
                {
                    _ItemsInPlayerInventory.ItemID.Add(ItemID);
                    _ItemsInPlayerInventory.Amount.Add(Inventory.AmountOf(ItemID));
                }
            }
            return _ItemsInPlayerInventory;
        }

        public static int CalculateItemWeight(int ItemID, int Amount, Dictionary<int, int> ItemIDWeights = null)
        {
            ItemIDWeights ??= _ItemIDWeights;
            return ItemIDWeights[ItemID] * Amount;
        }

        public static int CalculateInventoryWeight(ItemIDAndAmount Inventory, Dictionary<int, int> ItemIDWeights = null)
        {
            ArgumentNullException.ThrowIfNull(Inventory);

            ItemIDWeights ??= _ItemIDWeights;

            int Weight = 0;

            for (int index = 0; index < Inventory.ItemID.Count; index++)
            {
                int ItemID = Inventory.ItemID[index];
                int Amount = Inventory.Amount[index];

                Weight += ItemIDWeights[ItemID] * Amount;
            }

            return Weight;
        }



        private void OnItemPickup(ItemInstance ItemInstance)
        {
            int ItemID = ItemInstance._itemID;
            
        }

        public InventoryWeight()
        {

            // Uncomment any of these if you need a method to run on a specific update loop.
            //OnUpdateCallback = MyUpdateMethod;
            //OnLateUpdateCallback = MyLateUpdateMethod;
            //OnFixedUpdateCallback = MyFixedUpdateMethod;
            //OnGUICallback = MyGUIMethod;

            // Uncomment this to automatically apply harmony patches in your assembly.
            HarmonyPatchAll = true;
        }

        protected override void OnInitializeMod()
        {
            // Do your early mod initialization which doesn't involve game or sdk references here
            Config.Init();
        }

        protected override void OnSdkInitialized()
        {
            // Do your mod initialization which involves game or sdk references here
            // This is for stuff like UI creation, event registration etc.
            InventoryWeightUi.Create();

            // Add in-game settings ui for your mod.
            SettingsRegistry.CreateSettings(this, null, typeof(Config));
        }

        protected override void OnGameStart()
        {
            PlayerInventory Inventory = LocalPlayer.Inventory;


            
            if (Config.DebugMode.Value == true)
            {
                ItemIDAndAmount ItemsInInventory = GetAllItemInInventory(Inventory);
                for (int index = 0; index < ItemsInInventory.ItemID.Count; index++)
                {
                    RLog.Msg($"LocalPlayer has: {ItemsInInventory.Amount[index]} {ItemsInInventory.ItemID[index]} in inventory ");
                }
            }
        }
    }
}        

