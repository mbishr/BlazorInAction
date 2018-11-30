using FluentMigrator;

namespace EBikeShop.Server
{
    [Migration(20181130113600)]
    public class AddStateTaxTable : Migration
    {
        private const string TableName = "state_tax";

        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("StateCode").AsString(2).NotNullable()
                .WithColumn("StateName").AsString(32).NotNullable()
                .WithColumn("TaxRate").AsCurrency().NotNullable();
            
            Insert.IntoTable(TableName)
                .Row(new {StateCode = "UT", StateName = "Utah", TaxRate = 6.85m})
                .Row(new {StateCode = "NV", StateName = "Nevada", TaxRate = 8.00m})
                .Row(new {StateCode = "TX", StateName = "Texas", TaxRate = 6.25m})
                .Row(new {StateCode = "AL", StateName = "Alabama", TaxRate = 4.00m})
                .Row(new {StateCode = "CA", StateName = "California", TaxRate = 8.25m});
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}