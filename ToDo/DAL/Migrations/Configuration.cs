using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<MainContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(MainContext context)
		{
		}
	}
}