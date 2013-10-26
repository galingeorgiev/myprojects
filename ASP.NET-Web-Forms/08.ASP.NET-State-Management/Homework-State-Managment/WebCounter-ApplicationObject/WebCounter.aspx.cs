using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebCounter_ApplicationObject
{
    public partial class WebCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            if (Application["Users"] == null)
            {
                Application["Users"] = 0;
            }
            else
            {
                Application["Users"] = (int)Application["Users"] + 1;
            }

            string count = Application["Users"].ToString();
            Application.UnLock();

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