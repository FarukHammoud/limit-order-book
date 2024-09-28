namespace Helpers {
    public static class SimpleIntDescriptionHelper {
        public static string SimpleDescription(int number) {
            if(number > 1e9) {
                return $"{number/1e9}B";
            }else if (number > 1e6) {
                return $"{number / 1e6}M";
            } else if (number > 1e3) {
                return $"{number / 1e3}K";
            }
            return $"{number}";
        }
    }
}