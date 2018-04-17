namespace CrossbridgeContacts.WebApplication.Migrations
{
    using Contacts.WebApplication.Models;
    using ExcelDataReader;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrossbridgeContacts.WebApplication.Models.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrossbridgeContacts.WebApplication.Models.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            base.Seed(context);

            LoadExcel(context);
        }

        private void LoadExcel(CrossbridgeContacts.WebApplication.Models.DataBaseContext context)
        {
            FileStream stream = File.Open(AppDomain.CurrentDomain.BaseDirectory + "../Files/contacts.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelReader.AsDataSet();

            DataTable dt = result.Tables[0];
            dt.Rows.RemoveAt(0);

            var contacts = new List<Contact>();

            foreach (DataRow dr in dt.Rows)
            {

                contacts.Add(new Contact()
                {
                    IdContact = int.Parse(dr[0].ToString()),
                    Company = dr[1].ToString(),
                    FullName = dr[2].ToString(),
                    FirstName = dr[3].ToString(),
                    Middle = dr[4].ToString(),
                    LastName = dr[5].ToString(),
                    Email = dr[6].ToString(),
                    Department = dr[7].ToString(),
                    Title = dr[8].ToString()
                });
            }


            contacts.ForEach(s => context.Contacts.AddOrUpdate(p => p.IdContact, s));
            //context.Contacts.AddRange(contacts);
            context.SaveChanges();

        }
    }
}
