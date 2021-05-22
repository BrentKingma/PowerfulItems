using BepInEx;
using RoR2;
using R2API;
using R2API.Utils;
using UnityEngine;

namespace PowerfulItems
{
    [BepInDependency(R2API.R2API.PluginGUID)]
    [R2APISubmoduleDependency(nameof(ItemAPI), nameof(LanguageAPI))]
    [R2APISubmoduleDependency(nameof(CommandHelper))]
    [BepInPlugin("com.github.brentkingma.powerfulitems", "Powerful Items", "0.2.0")]
    public class PowerfulItems : BaseUnityPlugin
    {

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
            if (Input.GetKeyDown(KeyCode.F3))
            {
                //Get the player body to use a position:	
                var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;
                //And then drop our defined item in front of the player.
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(Assets.ExtendedMagItemDef.itemIndex), transform.position, transform.forward * 20f);
            }
        }
    }
}

///Survivor Index Numbers
///0: Bandit
///1: Captian
///2: Cammando
///3: Acrid
///4: Engineer
///5: 
///6: Huntress
///7: Loader
///8: Artificer
///9: Mercenary
///10: MUL-T
///11: REX
