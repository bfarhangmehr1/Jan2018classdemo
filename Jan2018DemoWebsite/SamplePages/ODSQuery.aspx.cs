using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ODSQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // first we wish to access to specific row 
            // that was selected by pressign the view lindk 
            // which is the selected command button of the gridview
            // remember the view link a command button

            GridViewRow agrvrow = AlbumList.Rows[AlbumList.SelectedIndex];

            //access the data from grid veiw templete control use .FindContol("IdControlName") to acccess the desired control

            string albumid = (agrvrow.FindControl("AlbumId") as Label).Text;

            // send the extracted value to another specified page 
            //pagename? parameterset & parameterset&...
            //? parameter set following 
            // parameter set idlable=value
            // & seperate multiple parameter sets
            // we could use session cookie or parnament cookie instead.
            // by changing the expiry date we could disable parnament cookie
            Response.Redirect("AlbumDetailes.aspx?aid=" + albumid);
        }
    }
}