namespace practice_BeehiveControlOOPPractice
{
    static class HoneyVault
    {
        const float NECTAR_CONVERSION_RATIO = .25f;
        const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;
        public static string StatusReport
        {
            get
            {
                string status = $"{honey:0.0} units of honey\n" +
                                $"{nectar:0.0} units of nectar";
                string warnings = "";
                if (honey < LOW_LEVEL_WARNING) warnings +=
                                    "\nLOW HONEY - ADD A HONEY MANUFACTURER";
                if (nectar < LOW_LEVEL_WARNING) warnings +=
                                    "\nLOW NECTAR - ADD A NECTAR COLLECTOR";
                return status + warnings;
            }
        }



        public static void CollectNectar(float amount)
        {
            if (amount > 0f) nectar += amount;
        }

        public static void ConvertNectarToHoney(float nectarToConvert)
        {
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount)
            {
                honey -= amount;
                return true;
            }
            else return false;
        }

    }
}
