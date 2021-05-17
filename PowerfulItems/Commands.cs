using RoR2;
using UnityEngine;

namespace PowerfulItems
{
    public class Commands
    {
        public static float interactableCreditMulti = 1.0f;

        [ConCommand(commandName = "set_chest_spawn_multiplier", flags = ConVarFlags.None, helpText = "Applies a multiplier to the number of chests that spawn.")]
        private static void CCSetChestMulitplier(ConCommandArgs args)
        {
            args.CheckArgumentCount(1);

            if(!int.TryParse(args[0], out var multiplier))
            {
                Debug.Log("Invalid Argument");
            }
            else
            {
                interactableCreditMulti = multiplier;
            }
        }
        [ConCommand(commandName = "get_chest_spawn_multiplier", flags = ConVarFlags.None, helpText = "Returns the multiplier of chest spawns")]
        private static void CCGetChestMulitplier(ConCommandArgs args)
        {
            Debug.Log(args.Count != 0
                ? "Invalid arguments. Did you mean set_chest_spawn_multiplier?"
                : $"Your multiplier is currently {interactableCreditMulti}. Good luck!");
        }

    }
}
