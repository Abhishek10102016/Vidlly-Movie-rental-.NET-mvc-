namespace Vidlly.Migrations
{
    using Stripe;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setNameOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name= 'pay as you go' where Id=1");
            Sql("Update MembershipTypes SET Name= 'Monthly' where Id=2");
            Sql("Update MembershipTypes SET Name= 'Quaterly' where Id=3");
            Sql("Update MembershipTypes SET Name= 'Annual' where Id=4");

        }
        
        public override void Down()
        {
        }
    }
}
