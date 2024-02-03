namespace UC12_AulaCRUD.Global
{
    public class Config
    {
        public static string dbHost = string.Empty;
        public static string dbPort = string.Empty;
        public static string dbName = string.Empty;
        public static string dbUser = string.Empty;
        public static string dbPass = string.Empty;

        public static void LoadConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            
            try
            {
                dbHost = config.GetValue<string>("DataBase:DbHost");
                dbPort = config.GetValue<string>("DataBase:dbPort");
                dbName = config.GetValue<string>("DataBase:dbName");
                dbUser = config.GetValue<string>("DataBase:dbUser");
                dbPass = config.GetValue<string>("DataBase:dbPass");
               
            }
            catch (Exception ex)
            { }
        }
    }
}
