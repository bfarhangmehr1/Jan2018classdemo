
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional namespaces
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

        protected void CountAlbums_Click(object sender, EventArgs e)
        {
            //traversing a grid veiw display
            // the only records avalilbale to us at this time out of dataset assigned to the grid view , are the rows being display

            // create a list<T> to hold the count of display

            List<ArtistAlbumCounts> Artists = new List <ArtistAlbumCounts>();
            // reusable pointer to an  instance of the specifeid class

            ArtistAlbumCounts item = null;
            int artistid = 0;
            //set up the loop to traverse the grid view

            foreach ( GridViewRow line in AlbumList.Rows)
            {
                // access the artistid
                artistid = int.Parse((line.FindControl("ArtistList") as DropDownList).SelectedValue);

                // determine if you alrtedy creat count instance in the list of <T> for this artist
                // if not, create a new instance for the artist and set its count to 1
                // if found , increment the counter

                // search for artist in list<T>
                // what will be return either null or the instance in the list of T
                item = Artists.Find(x => x.ArtistId==artistid);
                if (item == null)
                {
                    //create instance, initialuze , add to list<T>
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
            // attach the list of T (collection)to the display control
            ArtistAlbumCountList.DataSource = Artists;
            ArtistAlbumCountList.DataBind();
        }
    }
}