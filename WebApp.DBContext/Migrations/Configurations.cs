using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApp.Data.Entities;
using static WebApp.Common.Util.Enum;

namespace WebApp.DBContext.Migrations
{
    public class Configurations : DbMigrationsConfiguration<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
            context.Set<Person>().AddOrUpdate(
                new Person(1, DateTime.Now, "Le Nguyen Khang", "khang@gmail.com", "0123456789", DateTime.Now, Gender.Male, "123")
            );
        }
    }
}