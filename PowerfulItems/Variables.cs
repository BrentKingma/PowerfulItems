using BepInEx.Configuration;
using RoR2;

namespace PowerfulItems
{
    class Variables
    {
        public static ConfigEntry<float> interactableMultiplier { get; set; }
        public static ConfigEntry<float> moneyMultiplier { get; set; }


        private static CharacterBody characterBody {get; set;}
        public static CharacterBody MyBody
        {
            get => characterBody;
            set => characterBody = value;
        }
        private static int myCharacterIndex { get; set; }
        public static int MyCharacterIndex
        {
            get => myCharacterIndex;
            set => myCharacterIndex = value;
        }

        private static bool hasHuntressInGame { get; set; } = false;
        public static bool HasHuntress
        {
            get => hasHuntressInGame;
            set => hasHuntressInGame = value;
        }
        private static bool hasBanditInGame { get; set; } = false;
        public static bool HasBandit
        {
            get => hasBanditInGame;
            set => hasBanditInGame = value;
        }

        private static float defaultHuntressTrackingDistance { get; set; }
        public static float DefaultHuntressTrackingDistance
        {
            get => defaultHuntressTrackingDistance;
            set => defaultHuntressTrackingDistance = value;
        }
    }
}
