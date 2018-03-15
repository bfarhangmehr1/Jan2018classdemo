using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using Chinook.Data.POCOs;
#endregion

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }
       

        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
                       
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Artist";
                SearchArgID.Text = ArtistDDL.SelectedValue;
                TracksSelectionList.DataBind();
            },"Tracks by Artist","Add an artist track to your playlist by clicking on the +(plus sign).");
        }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "MediaType";
                SearchArgID.Text = MediaTypeDDL.SelectedValue;
                TracksSelectionList.DataBind();
            }, "Tracks by MediaType", "Add an MediaType track to your playlist by viewing on the column.");
        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Genre";
                SearchArgID.Text = GenreDDL.SelectedValue;
                TracksSelectionList.DataBind();
            }, "Tracks by Genre", "Add an Genre track to your playlist by viewing on the column.");
        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Album";
                SearchArgID.Text = AlbumDDL.SelectedValue;
                TracksSelectionList.DataBind();
            }, "Tracks by Album", "Add an Album track to your playlist by viewing on the column.");
        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Required Data", "Playlist Name is requied to retrive tracks.");
            }else
            {
                string username = "HansenB";
                string Playlistname = PlaylistName.Text;
                MessageUserControl.TryRun(() =>
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    List<UserPlaylistTrack> results = sysmgr.List_TracksForPlaylist(Playlistname, username);
                    if(results.Count()==0)
                    {
                        MessageUserControl.ShowInfo("check playlist name");
                    }
                    PlayList.DataSource = results;
                    PlayList.DataBind();
                });
            }
           
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {

            if (PlayList.Rows.Count == 0)
            {
                MessageUserControl.ShowInfo("Warning", "You must have playlist showing.Fetch your playlist");

            }
            else
            {
                if (string.IsNullOrEmpty(PlaylistName.Text))
                {
                    MessageUserControl.ShowInfo("Warning", "You must have playlist name .Enter your playlist name");

                    //optionally you might wish to empty the playlist GridView
                    // is so extract the needed data from selected GridViewRow
                    // the trackid is a hidden column on the GridView
                    int trackid = 0;
                    int tracknumber = 0;
                    int rowsselected = 0;
                    CheckBox playlistselection = null;
                    for (int rowindex = 0; rowindex < PlayList.Rows.Count; rowindex++)
                    {
                        //access the contorol on the selected GridviewRow
                        playlistselection = PlayList.Rows[rowindex].FindControl("Selected") as CheckBox;
                        if (playlistselection.Checked)
                        {
                            rowsselected++; //counter for number of checked items
                            //save necessary data for moving track
                            trackid = int.Parse((PlayList.Rows[rowindex].FindControl("TrackID") as Label).Text);
                            tracknumber = int.Parse((PlayList.Rows[rowindex].FindControl("TrackID") as Label).Text);
                        }
                    }
                    //how many tracks were checked
                    if (rowsselected != 1)
                    {
                        MessageUserControl.ShowInfo("Warning", "select one track to move.");
                    }
                    else
                    {
                        //is the selcted track the first track
                        if (tracknumber == PlayList.Rows.Count)
                        {
                            MessageUserControl.ShowInfo("Warning", "track can not be moved down.");
                        }
                        else
                        {
                            //move the track.
                            MoveTrack(trackid, tracknumber, "up");

                        }
                    }
                }
            }
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            
            if(PlayList.Rows.Count==0)
            {
                MessageUserControl.ShowInfo("Warning", "You must have playlist showing.Fetch your playlist");

            }
            else
            {
                if(string.IsNullOrEmpty(PlaylistName.Text))
                {
                    MessageUserControl.ShowInfo("Warning", "You must have playlist name .Enter your playlist name");

                    //optionally you might wish to empty the playlist GridView
                    // is so extract the needed data from selected GridViewRow
                    // the trackid is a hidden column on the GridView
                    int trackid = 0;
                    int tracknumber = 0;
                    int rowsselected = 0;
                    CheckBox playlistselection = null;
                     for( int rowindex=0; rowindex<PlayList.Rows.Count; rowindex++)
                    {
                        //access the contorol on the selected GridviewRow
                        playlistselection = PlayList.Rows[rowindex].FindControl("Selected") as CheckBox;
                        if(playlistselection.Checked)
                        {
                            rowsselected++; //counter for number of checked items
                            //save necessary data for moving track
                            trackid = int.Parse((PlayList.Rows[rowindex].FindControl("TrackID") as Label).Text);
                            tracknumber = int.Parse((PlayList.Rows[rowindex].FindControl("TrackID") as Label).Text);
                        }
                    }
                     //how many tracks were checked
                     if(rowsselected!=1)
                    {
                        MessageUserControl.ShowInfo("Warning", "select one track to move.");
                    }
                     else
                    {
                        //is the selcted track the first track
                        if (tracknumber == 1)
                        {
                            MessageUserControl.ShowInfo("Warning", "track can not be moved up.");
                        }
                        else
                        {
                            //move the track.
                            MoveTrack(trackid, tracknumber, "up");
                        }
                    }
                }
            }
        }
        protected void MoveTrack(int trackid, int tracknnumber, string direction)
        {
            // call Bll to move the track
            MessageUserControl.TryRun(() => {
                PlaylistTracksController sysmgr = new PlaylistTracksController();
                sysmgr.MoveTrack("HansenB", PlaylistName.Text, trackid, tracknnumber, direction);
                List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, "HansenB");
                PlayList.DataSource = info;
                PlayList.DataBind();
            }, "Moved", "track has been moved" + direction);
        }
        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            //code to go here

        }

        protected void TracksSelectionList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //this methode only execute if the user has press the plus sign on a visible row from the display 
            if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("PlayList Name", "you must supply playlist name.");
            }
            else
            {
                //via security one can obtain the username
                string username = "HandsenB";
                string playlistname = PlaylistName.Text;
                //trachId is attached to each listview row via the command argument Parameter
                //access to the trackid is done via listViewcommandEventArg e parameter
                // the e parameter is treated as object
                //some e parameter need to be cast as stings
                int trackid = int.Parse(e.CommandArgument.ToString());


                //all requied data can now be sent to BLL for further proessing 
                // user friendly error handling
                MessageUserControl.TryRun(() =>
                {
                    //connect to your BLL
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    sysmgr.Add_TrackToPLaylist(playlistname, username, trackid);

                    //code to retrive the up to date playlist and tracks for refreshing the playlist tracklist
                    List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(playlistname, username);
                    PlayList.DataSource = info;
                    PlayList.DataBind();

                },"Track Added","The track has been added, check your list below");
            }
           
        }

    }
}