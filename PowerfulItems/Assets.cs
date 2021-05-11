using System.Reflection;
using R2API;
using RoR2;
using UnityEngine;

namespace PowerfulItems
{
    internal static class Assets
    {
        internal static GameObject GerladMagPrefab;
        internal static Sprite GerladMagIcon;

        internal static ItemDef GerladMagItemDef;
        //internal static EquipmentDef BiscoLeashEquipmentDef;

        private const string ModPrefix = "@PowerfulItems:";

        internal static void Init()
        {
            // First registering your AssetBundle into the ResourcesAPI with a modPrefix that'll also be used for your prefab and icon paths
            // note that the string parameter of this GetManifestResourceStream call will change depending on
            // your namespace and file name
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PowerfulItems.models"))
            {
                var bundle = AssetBundle.LoadFromStream(stream);

                GerladMagPrefab = bundle.LoadAsset<GameObject>("Assets/magglass/model/magglass.prefab");
                GerladMagIcon = bundle.LoadAsset<Sprite>("Assets/magglass/portrait/magglassport.png");
                //BiscoLeashPrefab = bundle.LoadAsset<GameObject>("Assets/Import/belt/belt.prefab");
                //BiscoLeashIcon = bundle.LoadAsset<Sprite>("Assets/Import/belt_icon/belt_icon.png");

            }

            GerladMagAsRedTierItem();
            //BiscoLeashAsEquipment();

            AddLanguageTokens();
        }

        private static void GerladMagAsRedTierItem()
        {
            GerladMagItemDef = new ItemDef
            {
                name = "MagnifyingGlass", // its the internal name, no spaces, apostrophes and stuff like that
                tier = ItemTier.Tier3,
                pickupModelPrefab = GerladMagPrefab,
                pickupIconSprite = GerladMagIcon,
                nameToken = "BISCOLEASH_NAME", // stylised name
                pickupToken = "BISCOLEASH_PICKUP",
                descriptionToken = "BISCOLEASH_DESC",
                loreToken = "BISCOLEASH_LORE",
                tags = new[]
                {
                    ItemTag.AIBlacklist,
                    ItemTag.Utility
                }
            };

            var itemDisplayRules = new ItemDisplayRule[1]; // keep this null if you don't want the item to show up on the survivor 3d model. You can also have multiple rules !
            itemDisplayRules[0].followerPrefab = GerladMagPrefab; // the prefab that will show up on the survivor
            itemDisplayRules[0].childName = "Chest"; // this will define the starting point for the position of the 3d model, you can see what are the differents name available in the prefab model of the survivors
            itemDisplayRules[0].localScale = new Vector3(0.15f, 0.15f, 0.15f); // scale the model
            itemDisplayRules[0].localAngles = new Vector3(0f, 180f, 0f); // rotate the model
            itemDisplayRules[0].localPos = new Vector3(-0.35f, -0.1f, 0f); // position offset relative to the childName, here the survivor Chest

            var biscoLeash = new R2API.CustomItem(GerladMagItemDef, itemDisplayRules);

            ItemAPI.Add(biscoLeash); // ItemAPI sends back the ItemIndex of your item
        }

        //private static void BiscoLeashAsEquipment()
        //{
        //    BiscoLeashEquipmentDef = new EquipmentDef
        //    {
        //        name = "Leash", // its the internal name, no spaces, apostrophes and stuff like that
        //        cooldown = 5f,
        //        pickupModelPrefab = BiscoLeashPrefab,
        //        pickupIconSprite = BiscoLeashIcon,
        //        nameToken = "BISCOLEASH_NAME", // stylised name
        //        pickupToken = "BISCOLEASH_PICKUP",
        //        descriptionToken = "BISCOLEASH_DESC",
        //        loreToken = "BISCOLEASH_LORE",
        //        canDrop = true,
        //        enigmaCompatible = false
        //    };

        //    var itemDisplayRules = new ItemDisplayRule[1]; // keep this null if you don't want the item to show up on the survivor 3d model. You can also have multiple rules !
        //    itemDisplayRules[0].followerPrefab = BiscoLeashPrefab; // the prefab that will show up on the survivor
        //    itemDisplayRules[0].childName = "Chest"; // this will define the starting point for the position of the 3d model, you can see what are the differents name available in the prefab model of the survivors
        //    itemDisplayRules[0].localScale = new Vector3(0.15f, 0.15f, 0.15f); // scale the model
        //    itemDisplayRules[0].localAngles = new Vector3(0f, 180f, 0f); // rotate the model
        //    itemDisplayRules[0].localPos = new Vector3(-0.35f, -0.1f, 0f); // position offset relative to the childName, here the survivor Chest

        //    var biscoLeash = new CustomEquipment(BiscoLeashEquipmentDef, itemDisplayRules);

        //    ItemAPI.Add(biscoLeash);
        //}

        private static void AddLanguageTokens()
        {
            //The Name should be self explanatory
            LanguageAPI.Add("BISCOLEASH_NAME", "Detective's Magnifying Glass");
            //The Pickup is the short text that appears when you first pick this up. This text should be short and to the point, nuimbers are generally ommited.
            LanguageAPI.Add("BISCOLEASH_PICKUP", "Improve Vision and Sight");
            //The Description is where you put the actual numbers and give an advanced description.
            LanguageAPI.Add("BISCOLEASH_DESC",
                "Grants <style=cDeath>SIGHT AND VISION</style>.");
            //The Lore is, well, flavor. You can write pretty much whatever you want here.
            LanguageAPI.Add("BISCOLEASH_LORE",
                "Detective Gerald always had the ability to see things at ranges and quality using his magic magnifying glass.");
        }
    }
}
// \n<style=cDeath>RAMPAGE</style> : Specifics rewards for reaching kill streaks. \nIncreases <style=cIsUtility>movement speed</style> by <style=cIsUtility>1%</style> <style=cIsDamage>(+1% per item stack)</style> <style=cStack>(+1% every 20 Rampage Stacks)</style>. \nIncreases <style=cIsUtility>damage</style> by <style=cIsUtility>2%</style> <style=cIsDamage>(+2% per item stack)</style> <style=cStack>(+2% every 20 Rampage Stacks)</style>."

//Models Used Credits
//"Magnifying Glass Model" (https://skfb.ly/6WRUE) by Three_dots is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).