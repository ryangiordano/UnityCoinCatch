namespace Coin_Catch.Assets.Scripts.utility
{   

    public static class BonusMultiplier
    {
        private static int MultiplierAmount = 1;
        public static int GetScore(int score){
            return score*MultiplierAmount; 
        }
        public static void SetMultiplierAmount(int multiplier){
            MultiplierAmount = multiplier;
        }
        public static void ResetMultiplierAmount(){
            MultiplierAmount = 1;
        }
        
    }
}