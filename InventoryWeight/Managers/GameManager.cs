using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Items.Inventory;
using TheForest.Utils;
using static InventoryWeight.InventoryWeight;

namespace InventoryWeight.Managers
{
    internal class GameManager
    {
        public static Dictionary<int, int> PlayerInventoryItems { get; set; } = new Dictionary<int, int>();
        public static int[] AllitemIdArray = { 340, 356, 359, 367, 379, 394, 396, 431, 474, 477, 503, 525, 663, 358, 360, 361, 386, 443, 459, 353, 365, 355, 422, 522, 485, 362, 363, 364, 369, 387, 370, 153, 711, 537, 215, 457, 125, 73, 736, 183, 683, 244, 765, 233, 813, 884, 174, 403, 463, 743, 753, 763, 784, 735, 945, 935, 545, 727, 274, 874, 904, 914, 924, 954, 995, 6, 397, 37, 495, 555, 565, 575, 586, 14, 214, 254, 334, 344, 384, 414, 644, 804, 815, 695, 705, 714, 374, 554, 564, 614, 623, 973, 983, 994, 4, 454, 484, 965, 975, 985, 996, 16, 26, 36, 46, 56, 67, 839, 540, 408, 409, 685, 761, 857, 728, 578, 385, 45, 66, 406, 346, 923, 34, 54, 104, 144, 154, 164, 184, 204, 430, 479, 496, 502, 527, 553, 560, 657, 366, 166, 452, 152, 652, 853, 415, 352, 536, 745, 395, 405, 421, 543, 442, 754, 861, 161, 261, 461, 516, 176, 176, 531, 265, 746, 756, 766, 776, 786, 846, 856, 866, 876, 916, 926, 936, 946, 951, 696, 269, 997, 177, 167, 207, 216, 906, 315, 231, 42, 410, 509, 633, 467, 627, 666, 670, 671, 672, 679, 680, 681, 682, 688, 701, 709, 710, 726, 662, 669, 468, 957, 86, 712, 770, 748, 65, 165, 271, 656, 738, 40, 241, 348, 658, 944, 434, 135, 439, 143, 542, 642, 843, 246, 847, 151, 752, 959, 62, 39, 950, 837, 238, 338, 948, 952 };

        // "d" stands for default
        public static float d_RunSpeed = 5.4f;
        public static float d_WalkSpeed = 2.6f;
        public static float d_SwimSpeed = 3f;
        public static float d_CrouchSpeed = 3f;

        public static List<int> ItemIdsHeavyMeleeWeapons = new List<int>()
            {
                340, // guitar
                356, // modern axe
                431, // fire axe
            };
        public static List<int> ItemIdsLightMeleeWeapons = new List<int>()
            {
                359, // machete
                367, // katana
                379, // tactical axe
                394, // chainsaw
                396, // electric club
                474, // spear
                503, // torch
                525, // club
                663, // pickaxe
                485  // Shovel 
            };
        public static List<int> ItemIdsHeavyRangedWeapons = new List<int>()
            {
                358, // shotgun
                360, // compound Bow
                361, // rifle
                365, // crossbow
            };
        public static List<int> ItemIdsLightRangedWeapons = new List<int>()
            {
                386, // revolver
                443, // homemade bow
                459, // slingshot
                353, // taser
                355  // pistol
            };
        public static List<int> ItemIdsWeaponMods = new List<int>()
            {
                346, // shotgun mount
                374, // silencer
                375, // laser sight
                376, // pistol mount
                378  // gun flashlight
            };
        public static List<int> ItemIdsHeavyMaterials = new List<int>()
            {
                634, // solar panel
                414, // bottle of vodka
                416, // circuit board
                420, // c4 brick
                661, // battery
                517, // saucepan
                590, // radio
            };
        public static List<int> ItemIdsLightMaterials = new List<int>()
            {
                635, // light bulb
                403, // rope
                405, // bone
                418, // wire
                419, // duct tape
                430, // skull
                527, // batteries
                504, // tarp
            };
        public static List<int> ItemIdsVeryLightMaterials = new List<int>()
            {
                479, // feather
                496, // money
                502, // coins
                415, // cloth
                410, // wristwatch
            };
        public static List<int> ItemIdsFood = new List<int>()
            {
                421, // instant noodles
                425, // breakfast cereal
                433, // meat
                434, // canned food
                436, // fish
                438, // dry rations
                464, // cat food
                569, // piece of brain
                570, // piece of steak
                571, // piece of bacon
            };
        public static List<int> ItemIdsMedicineAndEnergy = new List<int>()
            {
                437, // pills
                441, // candy bar
                439, // energy drink
            };
        public static List<int> ItemIdsPlants = new List<int>()
            {
                397, // shiitake
                398, // oyster mushrooms
                399, // yellow hedgehog
                400, // fly agaric
                449, // devils club
                450, // horsetail
                451, // aloe vera
                452, // yarrow
                453, // cypress
                454, // balsamorrhiza
                465, // chicory
            };
        public static List<int> ItemIdsAmmunition = new List<int>()
            {
                373, // carbon fiber arrows
                368, // crossbow bolt
                362, // pistol cartridge
                363, // heavy bullets
                364, // buckshot
                369, // ammo for tasers
                387, // ammo for rifle
                370, // 1-5 pistol cartridges
                371, // 1-5 cartridges
                372, // 1-5 heavy bullets
                457, // 1-2 ammo for taser
                523, // zipline rope
            };
        public static List<int> ItemIdsThrowables = new List<int>()
            {
                524, // golf ball 
                381, // grenade
                417, // sticky bomb
                440, // signal fire
            };

        public static List<int> ItemIdsExpendables = new List<int>()
            {
                390, // printer resin
                469, // air tank
                508, // hide bag
            };
        public static List<int> ItemIdsTransport = new List<int>()
            {
                626, // paraglider
                630, // knight v

            };

        public static Dictionary<int, int> GetAllItemsInInventory(PlayerInventory inventory, int[] itemIdArray = null)
        {
            itemIdArray ??= AllitemIdArray;

            ArgumentNullException.ThrowIfNull(inventory);

            Dictionary<int, int> _ItemsInPlayerInventory = new Dictionary<int, int>();

            foreach (int itemId in itemIdArray)
            {
                if (inventory.AmountOf(itemId) != 0)
                {
                    _ItemsInPlayerInventory.Add(itemId, inventory.AmountOf(itemId));
                }
            }
            return _ItemsInPlayerInventory;
        }
    }
}
