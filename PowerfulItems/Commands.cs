using RoR2;
using UnityEngine;

namespace PowerfulItems
{
    public class Commands
    {
        [ConCommand(commandName = "set_interactables_spawn_multiplier", flags = ConVarFlags.None, helpText = "Applies a multiplier to the number of chests that spawn.")]
        private static void CCSetChestMulitplier(ConCommandArgs args)
        {
            args.CheckArgumentCount(1);

            if(!int.TryParse(args[0], out var multiplier))
            {
                Debug.Log("Invalid Argument");
            }
            else
            {
                Variables.InteractableMultiplier = multiplier;
            }
        }
        [ConCommand(commandName = "get_interactables_spawn_multiplier", flags = ConVarFlags.None, helpText = "Returns the multiplier of chest spawns")]
        private static void CCGetChestMulitplier(ConCommandArgs args)
        {
            Debug.Log(args.Count != 0
                ? "Invalid arguments. Did you mean set_chest_spawn_multiplier?"
                : $"Your multiplier is currently {Variables.InteractableMultiplier}.");
        }
        
        [ConCommand(commandName = "set_gold_multiplier", flags = ConVarFlags.None, helpText = "Applies a multiplier to the gold income.")]
        private static void CCSetGoldMulitplier(ConCommandArgs args)
        {
            args.CheckArgumentCount(1);

            if (!int.TryParse(args[0], out var multiplier))
            {
                Debug.Log("Invalid Argument");
            }
            else
            {
                Variables.MoneyMultiplier = multiplier;
            }
        }
        [ConCommand(commandName = "get_gold_multiplier", flags = ConVarFlags.None, helpText = "Returns the multiplier of gold")]
        private static void CCGetGoldMulitplier(ConCommandArgs args)
        {
            Debug.Log(args.Count != 0
                ? "Invalid arguments. Did you mean set_chest_spawn_multiplier?"
                : $"Your multiplier is currently {Variables.InteractableMultiplier}.");
        }
    }
}
