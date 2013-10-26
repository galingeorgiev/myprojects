using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.Data.Migrations;
using CF.Data;
using CF.Model;

namespace CF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion <CFContext, Configuration>());

            using (var db = new CFContext())
            {
                var uni = new UniversityCFTest() { Name = "Telerik" };
                var st = new StudentsCFTest() { UniversityId = 1 };

                db.Universities.Add(uni);
                db.Students.Add(st);
                db.SaveChanges();
            }
        }
    }
}