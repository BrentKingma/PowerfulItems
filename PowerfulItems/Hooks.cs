using BepInEx;
using R2API.Utils;
using RoR2;


namespace PowerfulItems
{
    class Hooks
    {
        internal static float defaultTrackingDistance;
        internal static bool hasHuntressInGame;
        internal static CharacterBody myBody;
        internal static void Init()
        {
            On.RoR2.Console.Awake += (orig, self) =>
            {
                CommandHelper.AddToConsoleWhenReady();
                orig(self);
            };
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
            On.RoR2.Run.Start += (orig, self) =>
            {
                foreach(var controller in PlayerCharacterMasterController.instances)
                {
                    if(controller.isLocalPlayer)
                    {
                        myBody = controller.master.bodyPrefab.GetComponent<CharacterBody>();
                        break;
                    }
                }
                orig(self);
            };
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
                    //Chat.AddMessage("Removed from available items");
                }
                orig(self);
            };
            On.RoR2.GenericPickupController.GetInteractability += (orig, self, activator) =>
            {
                if(PickupCatalog.GetPickupDef(self.pickupIndex).itemIndex == Assets.GerladMagItemDef.itemIndex && activator.GetComponent<HuntressTracker>() == null)
                {
                    return Interactability.ConditionsNotMet;
                }
                return orig(self, activator);
            };
            On.RoR2.GenericPickupController.OnTriggerStay += (orig, self, other) =>
            {
                if (PickupCatalog.GetPickupDef(self.pickupIndex).itemIndex == Assets.GerladMagItemDef.itemIndex && other.GetComponent<HuntressTracker>() == null)
                {
                    return;
                }
                orig(self, other);
            };

            On.RoR2.SceneDirector.PopulateScene += (orig, self) =>
            {
                self.interactableCredit = (int)(self.interactableCredit * Commands.interactableCreditMulti);
                orig(self);
            };
        }    
    }
}
