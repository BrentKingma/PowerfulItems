﻿using R2API.Utils;
using RoR2;


namespace PowerfulItems
{
    class Hooks
    {
        internal static void Init()
        {
            On.RoR2.Console.Awake += (orig, self) =>
            {
                CommandHelper.AddToConsoleWhenReady();
                orig(self);
            };
            On.RoR2.HuntressTracker.Awake += (orig, self) =>
            {
                orig(self);
                Variables.DefaultHuntressTrackingDistance = self.maxTrackingDistance;
            };
            On.RoR2.CharacterBody.OnInventoryChanged += (orig, self) =>
            {
                orig(self);
                if (self.isPlayerControlled && Variables.MyCharacterIndex == 6)
                {
                    self.GetComponent<HuntressTracker>().maxTrackingDistance = Variables.DefaultHuntressTrackingDistance + (15 * self.inventory.GetItemCount(Assets.GerladMagItemDef.itemIndex));
                }
                if(self.isPlayerControlled && Variables.MyCharacterIndex == 0)
                {
                    self.GetComponent<SkillLocator>().primary.SetBonusStockFromBody((self.inventory.GetItemCount(Assets.ExtendedMagItemDef.itemIndex)));
                    self.GetComponent<SkillLocator>().primary.stock = self.GetComponent<SkillLocator>().primary.maxStock;
                }
            };
            On.RoR2.Run.Start += (orig, self) =>
            {
                foreach (var controller in PlayerCharacterMasterController.instances)
                {
                    if (controller.isLocalPlayer)
                    {
                        Variables.MyBody = controller.master.bodyPrefab.GetComponent<CharacterBody>();
                        break;
                    }
                }
                orig(self);
            };
            On.RoR2.Run.BuildDropTable += (orig, self) =>
            {
                //foreach (var controller in PlayerCharacterMasterController.instances)
                //{
                //    if (controller.master.bodyPrefab.GetComponent<HuntressTracker>() != null)
                //    {
                //        Variables.HasHuntress = true;
                //        break;
                //    }
                //}
                if (!Variables.HasHuntress)
                {
                    self.availableItems.Remove(Assets.GerladMagItemDef.itemIndex);
                }
                if(!Variables.HasBandit)
                {
                    self.availableItems.Remove(Assets.ExtendedMagItemDef.itemIndex);
                }
                orig(self);
            };
            On.RoR2.GenericPickupController.GetInteractability += (orig, self, activator) =>
            {
                if (PickupCatalog.GetPickupDef(self.pickupIndex).itemIndex == Assets.GerladMagItemDef.itemIndex && Variables.MyCharacterIndex != 6)
                {
                    return Interactability.ConditionsNotMet;
                }
                if (PickupCatalog.GetPickupDef(self.pickupIndex).itemIndex == Assets.ExtendedMagItemDef.itemIndex && Variables.MyCharacterIndex != 0)
                {
                    return Interactability.ConditionsNotMet;
                }
                return orig(self, activator);
            };
            On.RoR2.GenericPickupController.OnTriggerStay += (orig, self, other) =>
            {
                if (PickupCatalog.GetPickupDef(self.pickupIndex).itemIndex == Assets.GerladMagItemDef.itemIndex && Variables.MyCharacterIndex != 6)
                {
                    return;
                }
                if (PickupCatalog.GetPickupDef(self.pickupIndex).itemIndex == Assets.ExtendedMagItemDef.itemIndex && Variables.MyCharacterIndex != 0)
                {
                    return;
                }
                orig(self, other);
            };
            On.RoR2.SceneDirector.PopulateScene += (orig, self) =>
            {
                self.interactableCredit = (int)(self.interactableCredit * Variables.InteractableMultiplier);
                orig(self);
            };
            On.RoR2.CharacterMaster.GiveMoney += (orig, self, amount) =>
            {
                amount = (uint)(amount * Variables.MoneyMultiplier);
                orig(self, amount);
            };
            On.RoR2.PreGameController.StartRun += (orig, self) =>
            {
                int count = NetworkUser.readOnlyInstancesList.Count;
                for (int i = 0; i < count; i++)
                {
                    var body = BodyCatalog.GetBodyPrefab(NetworkUser.readOnlyInstancesList[i].bodyIndexPreference);
                    int index = (int)SurvivorCatalog.FindSurvivorDefFromBody(body).survivorIndex;
                    //Stores your survivor index
                    if(i == 0)
                    {
                        Variables.MyCharacterIndex = index;
                    }
                    if (index == 0)
                    {
                        Variables.HasBandit = true;
                    }
                    if(index == 6)
                    {
                        Variables.HasHuntress = true;
                    }
                }

                orig(self);
            };
        }    
    }
}
