using BepInEx;
using RoR2;


namespace PowerfulItems
{
    class Hooks
    {
        internal static float defaultTrackingDistance;
        internal static bool hasHuntressInGame;
        internal static void Init()
        {
            On.RoR2.HuntressTracker.Awake += (orig, self) =>
            {
                Chat.AddMessage("Hunter Awoken");
                orig(self);
                defaultTrackingDistance = self.maxTrackingDistance;
            };
            On.RoR2.CharacterBody.OnInventoryChanged += (orig, self) =>
            {
                orig(self);
                if (self.isPlayerControlled && self.GetComponent<HuntressTracker>() != null)
                {
                    self.GetComponent<HuntressTracker>().maxTrackingDistance = defaultTrackingDistance + (15 * self.inventory.GetItemCount(Assets.GerladMagItemDef.itemIndex));
                }
            };
            //Checks if a huntress is present, if not removes custom item from loot pool
            On.RoR2.Run.BuildDropTable += (orig, self) =>
            {
                foreach (var controller in PlayerCharacterMasterController.instances)
                {
                    if (controller.master.bodyPrefab.GetComponent<HuntressTracker>() != null)
                    {
                        hasHuntressInGame = true;
                        break;
                    }
                }
                if (!hasHuntressInGame)
                {
                    self.availableItems.Remove(Assets.GerladMagItemDef.itemIndex);
                    Chat.AddMessage("Removed from available items");
                }
                orig(self);
            };
            On.RoR2.PickupPickerController.IsChoiceAvailable += (orig, self, choice) =>
            {
               // if()
                //{

               //     return false;
                //}
                return orig(self, choice);
            };
            Chat.AddMessage("Hooks Added");
        }    
    }
}
