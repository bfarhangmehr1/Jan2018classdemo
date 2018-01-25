using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class AlbumDetailes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // do the follieing on the  ast time throgh this page
            if (!Page.IsPostBack)
            {
                // respone.rediredt sent a value to htis page
                // request .querysting ["labelid"] will obtain the value sent by redirect the value is string  if no value was sent the vlue will be null
                string albumid = Request.QueryString["aid"];
                if (string.IsNullOrEmpty(albumid))
                {
                    Response.Redirect("ODSQuery.aspx");
                }
                else
                {
                    AlbumIDArg.Text = albumid;
                }
            }
        }


        protected void AlbumTracks_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // contains the value  that was attach to hte link on hte listview the property that you need to access is command Argument it is not string 
            CommandArgID.Text = e.CommandArgument.ToString();
            // extract a value from a column on the listview item (row)
            ColumnID.Text = (e.Item.FindControl("TrackIdLabel") as Label).Text;
        }

        protected void Totals_Click(object sender, EventArgs e)
        {
            double time = 0;
            double size = 0;

            // use foreach to cycle through the listview
            foreach(ListViewItem item in this.AlbumTracks.Items)
            {
                time += double.Parse((item.FindControl("MillisecondsLabel") as Label).Text);
                size += double.Parse((item.FindControl("BytesLabel") as Label).Text);
            }
            TracksTime.Text = time.ToString();
            TracksSize.Text = size.ToString();
        }
    }
}