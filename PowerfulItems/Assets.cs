using System.Reflection;
using R2API;
using RoR2;
using UnityEngine;

namespace PowerfulItems
{
    internal static class Assets
    {
        internal static GameObject MagnifingGlassPrefab;
        internal static Sprite MagnifingGlassIcon;
        internal static ItemDef MagnifingGlassItemDef;

        internal static GameObject ExtendedMagPrefab;
        internal static Sprite ExtendedMagIcon;
        internal static ItemDef ExtendedMagItemDef;

        private const string ModPrefix = "@PowerfulItems:";

        internal static void Init()
        {

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PowerfulItems.models"))
            {
                var bundle = AssetBundle.LoadFromStream(stream);

                MagnifingGlassPrefab = bundle.LoadAsset<GameObject>("Assets/magglass/model/magglass.prefab");
                MagnifingGlassIcon = bundle.LoadAsset<Sprite>("Assets/magglass/portrait/magglassport.png");
                ExtendedMagPrefab = bundle.LoadAsset<GameObject>("Assets/extmag/model/magbullet.prefab");
                ExtendedMagIcon = bundle.LoadAsset<Sprite>("Assets/extmag/portrait/mag.png");
            }

            LoadMagnifingGlass();
            LoadExtMag();

            AddLanguageTokens();
        }

        private static void LoadMagnifingGlass()
        {
            MagnifingGlassItemDef = new ItemDef
            {
                name = "MagnifyingGlass",
                tier = ItemTier.Tier3,
                pickupModelPrefab = MagnifingGlassPrefab,
                pickupIconSprite = MagnifingGlassIcon,
                nameToken = "MAGGLASS_NAME",
                pickupToken = "MAGGLASS_PICKUP",
                descriptionToken = "MAGGLASS_DESC",
                loreToken = "MAGGLASS_LORE",
                tags = new[]
                {
                    ItemTag.AIBlacklist,
                    ItemTag.Utility
                }
            };

            var itemDisplayRules = new ItemDisplayRule[1]; 
            itemDisplayRules[0].followerPrefab = MagnifingGlassPrefab;
            itemDisplayRules[0].childName = "Chest"; 
            itemDisplayRules[0].localScale = new Vector3(0.15f, 0.15f, 0.15f); 
            itemDisplayRules[0].localAngles = new Vector3(0f, 180f, 0f); 
            itemDisplayRules[0].localPos = new Vector3(-0.35f, -0.1f, 0f); 

            var biscoLeash = new R2API.CustomItem(MagnifingGlassItemDef, itemDisplayRules);

            ItemAPI.Add(biscoLeash); 
        }
        private static void LoadExtMag()
        {
            ExtendedMagItemDef = new ItemDef
            {
                name = "ExtMag", 
                tier = ItemTier.Tier2,
                pickupModelPrefab = ExtendedMagPrefab,
                pickupIconSprite = ExtendedMagIcon,
                nameToken = "EXTMAG_NAME", 
                pickupToken = "EXTMAG_PICKUP",
                descriptionToken = "EXTMAG_DESC",
                loreToken = "EXTMAG_LORE",
                tags = new[]
                {
                    ItemTag.AIBlacklist,
                    ItemTag.Utility
                }
            };

            var itemDisplayRules = new ItemDisplayRule[1]; 
            itemDisplayRules[0].followerPrefab = ExtendedMagPrefab; 
            itemDisplayRules[0].childName = "Waist"; 
            itemDisplayRules[0].localScale = new Vector3(0.15f, 0.15f, 0.15f);
            itemDisplayRules[0].localAngles = new Vector3(0f, 180f, 0f); 
            itemDisplayRules[0].localPos = new Vector3(-0.35f, -0.1f, 0f);

            var bagoMoney = new R2API.CustomItem(ExtendedMagItemDef, itemDisplayRules);

            ItemAPI.Add(bagoMoney); 
        }

        private static void AddLanguageTokens()
        {
            LanguageAPI.Add("MAGGLASS_NAME", "Detective's Magnifying Glass");
            LanguageAPI.Add("MAGGLASS_PICKUP", "Improve Vision and Sight");
            LanguageAPI.Add("MAGGLASS_DESC", "Grants <style=cDeath>SIGHT AND VISION</style>.");
            LanguageAPI.Add("MAGGLASS_LORE", "Detective Gerald always had the ability to see things at ranges and quality using his magic magnifying glass.");
            LanguageAPI.Add("EXTMAG_NAME", "Rambo's Extended Magazine");
            LanguageAPI.Add("EXTMAG_PICKUP", "Load extra rounds into your weapon.");
            LanguageAPI.Add("EXTMAG_DESC", "Gives <style=cDeath>LARGER AMMO CAPACITY</style>.");
            LanguageAPI.Add("EXTMAG_LORE", "Rambo was a mad lad but dropped his extended magazine on the field of battle. It was later found to have a weirdly large amount of ammo in it.");
        }
    }
}
// \n<style=cDeath>RAMPAGE</style> : Specifics rewards for reaching kill streaks. \nIncreases <style=cIsUtility>movement speed</style> by <style=cIsUtility>1%</style> <style=cIsDamage>(+1% per item stack)</style> <style=cStack>(+1% every 20 Rampage Stacks)</style>. \nIncreases <style=cIsUtility>damage</style> by <style=cIsUtility>2%</style> <style=cIsDamage>(+2% per item stack)</style> <style=cStack>(+2% every 20 Rampage Stacks)</style>."

//Models Used Credits
//"Magnifying Glass Model" (https://skfb.ly/6WRUE) by Three_dots is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).