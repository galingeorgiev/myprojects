using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Car;

namespace SearchingCars
{
    public partial class SearchingCars : System.Web.UI.Page
    {
        protected IEnumerable<Extra> GetExtras()
        {
            Extra aircondition = new Extra() { Name = "Aircondition" };
            Extra gps = new Extra() { Name = "GPS" };
            Extra esp = new Extra() { Name = "ESP" };
            Extra abs = new Extra() { Name = "ABS" };
            Extra airbag = new Extra() { Name = "Airbag" };

            var extres = new List<Extra>() { aircondition, gps, esp, abs, airbag };
            return extres;
        }

        protected IEnumerable<Producer> GetProducers()
        {
            Extra aircondition = new Extra() { Name = "Aircondition" };
            Extra gps = new Extra() { Name = "GPS" };
            Extra esp = new Extra() { Name = "ESP" };
            Extra abs = new Extra() { Name = "ABS" };
            Extra airbag = new Extra() { Name = "Airbag" };

            List<Model> bmwModels = new List<Model>()
            {
                 new Model() { Name = "320i", EngineType = EngineType.Benzine, Extras = new List<Extra>() { aircondition, airbag } },
                 new Model() { Name = "320d", EngineType = EngineType.Diesel, Extras = new List<Extra>() { aircondition, airbag, abs } },
                 new Model() { Name = "520i", EngineType = EngineType.Benzine, Extras = new List<Extra>() { aircondition, airbag, abs } },
                 new Model() { Name = "520d", EngineType = EngineType.Diesel, Extras = new List<Extra>() { aircondition, airbag, abs, esp } }
            };
            Producer bmw = new Producer() { Name = "BMW", Models = bmwModels };

            List<Model> toyotaModels = new List<Model>()
            {
                 new Model() { Name = "Avensis", EngineType = EngineType.Benzine, Extras = new List<Extra>() { aircondition, airbag, abs, esp, gps } },
                 new Model() { Name = "Corolla", EngineType = EngineType.Diesel, Extras = new List<Extra>() { aircondition, airbag, abs } },
                 new Model() { Name = "Auris", EngineType = EngineType.Benzine, Extras = new List<Extra>() { aircondition, airbag, abs } },
                 new Model() { Name = "Aigo", EngineType = EngineType.Diesel, Extras = new List<Extra>() { aircondition, airbag } }
            };
            Producer toyota = new Producer() { Name = "Toyota", Models = toyotaModels };

            List<Model> audiModels = new List<Model>()
            {
                 new Model() { Name = "A3", EngineType = EngineType.Benzine, Extras = new List<Extra>() { aircondition, airbag, abs } },
                 new Model() { Name = "A4", EngineType = EngineType.Diesel, Extras = new List<Extra>() { aircondition, airbag, abs } },
                 new Model() { Name = "A6", EngineType = EngineType.Benzine, Extras = new List<Extra>() { aircondition, airbag, abs, esp } },
                 new Model() { Name = "A8", EngineType = EngineType.Diesel, Extras = new List<Extra>() { aircondition, airbag, abs, esp, gps } }
            };
            Producer audi = new Producer() { Name = "Audi", Models = audiModels };

            List<Producer> producers = new List<Producer>() { bmw, audi, toyota };

            return producers;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var listOfProducers = this.GetProducers();
                this.DropDownProducers.DataSource = listOfProducers.Select(p => p.Name);
                this.DropDownProducers.DataBind();

                this.ListOfEngines.DataSource = Enum.GetNames(typeof(EngineType));
                this.ListOfEngines.DataBind();

                var extras = this.GetExtras();
                this.ListOfExtas.DataSource = extras.Select(x => x.Name);
                this.ListOfExtas.DataBind();
            }
        }

        protected void Producer_IndexChanged(object sender, EventArgs e)
        {
            var selectedProducer = this.DropDownProducers.SelectedValue;
            var listOfProducers = this.GetProducers();
            var listOfModels = listOfProducers.Where(p => p.Name == selectedProducer).Select(p => p.Models).FirstOrDefault();
            this.DropDownModels.DataSource = listOfModels.Select(n => n.Name); ;
            this.DropDownModels.DataBind();
        }

        protected void FoundCar_Click(object sender, EventArgs e)
        {
            var listOfProducers = this.GetProducers();
            var selectedProducer = this.DropDownProducers.SelectedValue;
            var selectedModel = this.DropDownModels.SelectedValue;
            var selectedEngine = this.ListOfEngines.SelectedItem.Text;
            List<string> selectedExtras = new List<string>();
            for (int i = 0; i < this.ListOfExtas.Items.Count; i++)
            {
                if (this.ListOfExtas.Items[i].Selected)
                {
                    selectedExtras.Add(this.ListOfExtas.Items[i].Text);
                }
            }

            var carsByProducer = (from p in listOfProducers
                                 where p.Name == selectedProducer
                                 select p).FirstOrDefault();

            var carsByModel = (from m in carsByProducer.Models
                              where m.Name == selectedModel && m.EngineType.ToString() == selectedEngine
                                   select m).FirstOrDefault();

            var isCarAvailable = true;

            if (carsByModel != null)
            {
                var selectedModelExtras = carsByModel.Extras.Select(n => n.Name);

                foreach (var extra in selectedExtras)
                {
                    if (!selectedModelExtras.Contains(extra))
                    {
                        isCarAvailable = false;
                    }
                }

                if (isCarAvailable)
                {
                    this.SearchResult.Text = string.Format("Producer: {0}; Model: {1}; Engine type: {2}; Extras: {3};",
                        carsByProducer.Name,
                        carsByModel.Name,
                        carsByModel.EngineType,
                        string.Join(", ", carsByModel.Extras));
                }
                else
                {
                    this.SearchResult.Text = "Nothing found";
                }
            }
            else
            {
                this.SearchResult.Text = "Nothing found";
            }
        }
    }
}