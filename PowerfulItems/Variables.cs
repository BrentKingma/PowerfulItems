using RoR2;

namespace PowerfulItems
{
    class Variables
    {
        private static float interactableMultiplier { get; set; } = 1.0f;
        public static float InteractableMultiplier
        {
            get => interactableMultiplier;
            set => interactableMultiplier = value;
        }

        private static float moneyMultiplier { get; set; } = 1.0f;
        public static float MoneyMultiplier 
        {
            get => moneyMultiplier;
            set => moneyMultiplier = value;
        }

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
