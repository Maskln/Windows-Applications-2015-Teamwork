namespace JustGoWebApp.Web.Api
{
    using JustGoWebApp.Data;
    using JustGoWebApp.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JustGoWebAppDbContext, Configuration>());
        }
    }
}
