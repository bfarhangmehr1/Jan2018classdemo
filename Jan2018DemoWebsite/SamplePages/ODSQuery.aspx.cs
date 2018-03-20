
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using Chinook.Data.POCOs;
#endregion

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ODSQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //first, we wish to access the specific row
            //that was selected by pressing the View link
            //which is the select command button of the
            //gridview.
            //remember, the View Link is a Command Button
            GridViewRow agvrow = AlbumList.Rows[AlbumList.SelectedIndex];

            //access the data from the GridView Template control
            //use the .FindControl("IdControlName") to
            //access the desired control
            string albumid = (agvrow.FindControl("AlbumId") as Label).Text;
            //send the extracted value to another specified page
            //pagename?parameterset&parameterset&....
            // ? parameter set following
            // Parameter set  idlabel=value
            // & separates multiple parameter sets
            Response.Redirect("AlbumDetails.aspx?aid=" + albumid);
        }

        protected void CountAlbums_Click(object sender, EventArgs e)
        {
            //traversing a GridView display
            //the only records available to us at this time
            //    out of the dataset assigned to the GridView
            //    are the row being display

            //create a List<T> to hold the counts of the display
            List<ArtistAlbumCounts> Artists = new List<ArtistAlbumCounts>();

            //reusable pointer to an instance of the specified class
            ArtistAlbumCounts item = null;
            int artistid = 0;

            //setup the loop to travser the gridview
            foreach(GridViewRow line in AlbumList.Rows)
            {
                //access the artistid
                artistid = int.Parse((line.FindControl("ArtistList") as DropDownList).SelectedValue);

                //determine if you have already created a count
                //   instance in the List<T> for this artists
                //if NOT, create a new instance for the artist and
                //     set its count to 1
                //if found, increment the counter (+1)

                //search for artist in list<T>
                //what will be return is either null (not found)
                //   or the instance in the List<T>
                item = Artists.Find(x => x.ArtistId == artistid);
                if(item == null)
                {
                    //Create instance, initialize, add to List<T>
                    item = new ArtistAlbumCounts();
                    item.ArtistId = artistid;
                    item.AlbumCount = 1;
                    Artists.Add(item);
                }
                else
                {
                    item.AlbumCount++;
                }
            }

            //attach the List<T> (collection) to the display control
            ArtistAlbumCountList.DataSource = Artists;
            ArtistAlbumCountList.DataBind();
        }
    }
}