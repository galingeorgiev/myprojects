using System;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word.Data;
using Word.Model;

namespace Word
{
    public partial class Word : System.Web.UI.Page
    {
        public void AddSampleData()
        {
            using (var db = new WordContext())
            {
                var checkForContinent = db.Continents.FirstOrDefault();

                if (checkForContinent == null)
                {
                    db.Continents.Add(new Continent() { Name = "Asia" });
                    db.Continents.Add(new Continent() { Name = "Africa" });
                    db.Continents.Add(new Continent() { Name = "North America" });
                    db.Continents.Add(new Continent() { Name = "South America" });
                    db.Continents.Add(new Continent() { Name = "Antarctica" });
                    db.Continents.Add(new Continent() { Name = "Europe" });
                    db.Continents.Add(new Continent() { Name = "Australia" });
                    db.SaveChanges();

                    Continent europe = db.Continents.Where(c => c.Name == "Europe").FirstOrDefault();
                    db.Countries.Add(new Country() { Name = "Albania", Continent = europe, Population = 3000000 });
                    db.Countries.Add(new Country() { Name = "Belgium", Continent = europe, Population = 1000000 });
                    db.Countries.Add(new Country() { Name = "Bulgaria", Continent = europe, Population = 8000000 });
                    db.Countries.Add(new Country() { Name = "Cyprus", Continent = europe, Population = 1000000 });
                    db.Countries.Add(new Country() { Name = "France", Continent = europe, Population = 63000000 });
                    db.Countries.Add(new Country() { Name = "Italy", Continent = europe, Population = 59000000 });
                    db.Countries.Add(new Country() { Name = "Russia", Continent = europe, Population = 142000000 });
                    db.SaveChanges();

                    Continent northAmerica = db.Continents.Where(c => c.Name == "North America").FirstOrDefault();
                    db.Countries.Add(new Country() { Name = "USA", Continent = northAmerica, Population = 3000000 });
                    db.Countries.Add(new Country() { Name = "Mexico", Continent = northAmerica, Population = 1000000 });
                    db.Countries.Add(new Country() { Name = "Canada", Continent = northAmerica, Population = 8000000 });
                    db.SaveChanges();

                    Country bulgaria = db.Countries.Where(c => c.Name == "Bulgaria").FirstOrDefault();
                    db.Towns.Add(new Town() { Name = "Sofia", Population = 2000000, Country = bulgaria });
                    db.Towns.Add(new Town() { Name = "Plovdiv", Population = 500000, Country = bulgaria });
                    db.Towns.Add(new Town() { Name = "Varna", Population = 400000, Country = bulgaria });
                    db.Towns.Add(new Town() { Name = "Burgas", Population = 400000, Country = bulgaria });
                    db.Towns.Add(new Town() { Name = "Stara Zagora", Population = 200000, Country = bulgaria });
                    db.SaveChanges();

                    Country russia = db.Countries.Where(c => c.Name == "Russia").FirstOrDefault();
                    db.Towns.Add(new Town() { Name = "Moscow", Population = 15000000, Country = russia });
                    db.Towns.Add(new Town() { Name = "Sanct Peterburg", Population = 500000, Country = russia });
                    db.SaveChanges();

                    Country france = db.Countries.Where(c => c.Name == "France").FirstOrDefault();
                    db.Towns.Add(new Town() { Name = "Paris", Population = 2000000, Country = france });
                    db.Towns.Add(new Town() { Name = "Tours", Population = 500000, Country = france });
                    db.Towns.Add(new Town() { Name = "Marsilly", Population = 400000, Country = france });
                    db.Towns.Add(new Town() { Name = "Lion", Population = 400000, Country = france });
                    db.Towns.Add(new Town() { Name = "Nice", Population = 200000, Country = france });
                    db.SaveChanges();

                    Country belgium = db.Countries.Where(c => c.Name == "Belgium").FirstOrDefault();
                    db.Towns.Add(new Town() { Name = "Brussel", Population = 15000000, Country = belgium });
                    db.Towns.Add(new Town() { Name = "Andwerpent", Population = 500000, Country = belgium });
                    db.SaveChanges();
                }
            }
        }

        protected void WordContextEntityDataSource_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            var db = new WordContext();
            e.Context = (db as IObjectContextAdapter).ObjectContext;
        }

        public void BindControls()
        {
            using (var db = new WordContext())
            {
                var continents = db.Continents.ToList();
                this.ListBoxContinents.DataSource = continents;
                this.ListBoxContinents.DataTextField = "Name";
                this.ListBoxContinents.DataValueField = "Id";
                this.ListBoxContinents.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AddSampleData();
            if (!Page.IsPostBack)
            {
                this.AddSampleData();
                //this.BindControls();
            }
        }

        protected string getImage(byte[] flag)
        {
            using (var db = new WordContext())
            {
                if (flag != null)
                {
                    string image = "data:image/jpeg;base64," + Convert.ToBase64String(flag);
                    return image;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FormViewContinent.PageIndex = this.ListBoxContinents.SelectedIndex;
            this.FormViewContinent.DataBind();
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewTowns_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.None;
        }

        protected void GridViewCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upload")
            {
                try
                {
                    FileUpload fileUpload = null;

                    for (int row = 0; row < this.GridViewCountries.Rows.Count; row++)
                    {
                        fileUpload = (FileUpload)this.GridViewCountries.Rows[row].FindControl("FileUploadFlag");
                        if (fileUpload.FileBytes.Count() > 0)
                        {
                            break;
                        }
                    }

                    if (fileUpload.FileBytes.Count() > 0)
                    {
                        //to allow only jpg gif and png files to be uploaded.
                        string extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                        if (((extension == ".jpg") || ((extension == ".gif") || (extension == ".png"))))
                        {
                            using (var db = new WordContext())
                            {

                                int selectedCountryId = int.Parse(e.CommandArgument.ToString());
                                var selectedCountry = db.Countries.FirstOrDefault(c => c.Id == selectedCountryId);
                                selectedCountry.Flag = fileUpload.FileBytes;
                                db.SaveChanges();

                                this.LabelContinent.Text = "Flag added!";
                            }

                            this.GridViewCountries.DataBind();
                        }
                        else
                        {
                            this.LabelContinent.Text = "Only jpg, gif or png files are permitted";
                        }
                    }
                    else
                    {
                        this.LabelContinent.Text = "Kindly Select a File.....";
                    }
                }
                catch (Exception ex)
                {
                    this.LabelContinent.Text = ex.Message;
                }
            }
        }
    }
}