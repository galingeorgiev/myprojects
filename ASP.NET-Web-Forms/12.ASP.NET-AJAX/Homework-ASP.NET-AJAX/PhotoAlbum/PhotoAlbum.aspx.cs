using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Web.Services;
using System.Web.Script.Services;

namespace PhotoAlbum
{
    public partial class PhotoAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        [ScriptMethod]
        public static AjaxControlToolkit.Slide[] GetSlides() 
        {
            Slide imgAlbania = new Slide("Images/Albania.jpg", "Albania", "Albania flag");
            Slide imgBelgium = new Slide("Images/Belgium.jpg", "Belgium", "Belgium flag");
            Slide imgBulgaria = new Slide("Images/bulgaria.jpg", "Bulgaria", "Bulgaria flag");
            Slide imgCyprus = new Slide("Images/Cyprus.jpg", "Cyprus", "Cyprus flag");
            Slide imgFrance = new Slide("Images/France.jpg", "France", "France flag");
            Slide imgItaly = new Slide("Images/Italy.jpg", "Italy", "Italy flag");
            Slide imgRussia = new Slide("Images/Russia.jpg", "Russia", "Russia flag");
            Slide[] slides = new Slide[] { imgAlbania, imgBelgium, imgBulgaria, imgCyprus, imgFrance, imgItaly, imgRussia };
            return slides;
        }
    }
}