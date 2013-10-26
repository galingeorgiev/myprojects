using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Register_Click(object sender, EventArgs e)
        {
            HtmlGenericControl firstName = new HtmlGenericControl("p");
            firstName.InnerText = "First name: " + this.TextBoxFirstName.Text;
            HtmlGenericControl lastName = new HtmlGenericControl("p");
            lastName.InnerText = "Last name: " + this.TextBoxLastName.Text;
            HtmlGenericControl facultiNumber = new HtmlGenericControl("p");
            facultiNumber.InnerText = "Faculty number: " + this.TextBoxFacultyNumber.Text;
            HtmlGenericControl university = new HtmlGenericControl("p");
            university.InnerText = "University: " + this.DropDownListUniversity.Text;
            HtmlGenericControl speciality = new HtmlGenericControl("p");
            speciality.InnerText = "Speciality: " + this.DropDownListSpeciality.Text;
            HtmlGenericControl course = new HtmlGenericControl("p");
            course.InnerText = "Course: " + this.DropDownListCourses.Text;

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = "RegisterInfo";
            div.Controls.Add(firstName);
            div.Controls.Add(lastName);
            div.Controls.Add(facultiNumber);
            div.Controls.Add(university);
            div.Controls.Add(speciality);
            div.Controls.Add(course);
            this.RegisterInfo.Controls.Add(div);
        }
    }
}