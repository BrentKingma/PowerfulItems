using BepInEx;
using RoR2;
using R2API;
using R2API.Utils;
using UnityEngine;

namespace PowerfulItems
{
    //[BepInDependency("com.bepis.r2api")]
    [BepInDependency(R2API.R2API.PluginGUID)]
    [R2APISubmoduleDependency(nameof(ItemAPI), nameof(LanguageAPI))]
    [R2APISubmoduleDependency(nameof(CommandHelper))]
    [BepInPlugin("com.github.brentkingma.powerfulitems", "Powerful Items", "1.0.0")]
    public class PowerfulItems : BaseUnityPlugin
    {
        //LocalUser user = null;
        //CharacterBody myBody = null;
        //HuntressTracker myTracker = null;

        public void Awake()
        {
            Assets.Init();
            Hooks.Init();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                //Get the player body to use a position:	
                var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;
                //And then drop our defined item in front of the player.
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(Assets.GerladMagItemDef.itemIndex), transform.position, transform.forward * 20f);
            }
        }
    }
}
