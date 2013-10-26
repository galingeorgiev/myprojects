using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCounter.Data;
using WebCounter.Model;
using System.Data.Entity;

namespace WebCounter_SQLServer
{
    public partial class WebCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string count = null;

            using (var db = new WebCounterContext())
            {
                Counter counter = db.Counts.FirstOrDefault();
                if (counter == null)
                {
                    db.Counts.Add(new Counter() { Count = 1 });
                    db.SaveChanges();
                    count = "1";
                }
                else
                {
                    counter.Count++;
                    db.SaveChanges();
                    count = counter.Count.ToString();
                }
            }

            Bitmap imageCount = new Bitmap(100, 100);
            using (imageCount)
            {
                Graphics gr = Graphics.FromImage(imageCount);
                using (gr)
                {
                    gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 100, 100);
                    gr.DrawString(count,
                        new Font("Arial", 12, FontStyle.Bold),
                        SystemBrushes.WindowText,
                        new Point(40, 40));

                    // Set response header and write the image into response stream
                    Response.ContentType = "image/gif";

                    //Response.AppendHeader("Content-Disposition",
                    //    "attachment; filename=\"Financial-Report-April-2013.gif\"");

                    imageCount.Save(Response.OutputStream, ImageFormat.Gif);
                }
            }
        }
    }
}