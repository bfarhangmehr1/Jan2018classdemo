using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
using DMIT2018Common.UserControls;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {
               
                //code to go here

                return null;
            }
        }//eom
        public void Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            List<string> reasons = new List<string>();
            // tihis will be used with the BussinessRuleException
            using (var context = new ChinookContext())
            {
                //PartOne
                //optional add of the new playlist
                //validate track
                //if a playlist already exist on the database
                Playlist exists = context.Playlists
                    .Where(x => x.Name.Equals(playlistname,StringComparison.OrdinalIgnoreCase) 
                    && x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)).Select(x => x).FirstOrDefault();

                PlaylistTrack newTrack = null;
                int tracknumber = 0;

                if(exists==null)
                {
                    //add parant record(playlist record)
                    //no tracks exsits yet for new playlist
                    //therefor the tracknumber is 1
                    exists = new Playlist();
                    exists.Name = playlistname;
                    exists.UserName = username;
                    exists = context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    //The playlist exsits on the database 
                    // playlist may or may not have any tracks
                    //adjast the track number to be the next track
                    tracknumber = exists.PlaylistTracks.Count() + 1;

                    //will this be a duplicate track?
                    //lookup the tracks of the playlist testing for incoming trackid
                    newTrack = exists.PlaylistTracks.SingleOrDefault(x => x.TrackId == trackid);   
                    
                    // validation rule: track may only exists once on the playlist
                    if(newTrack !=null)
                    {
                        //rule is violated 
                        //track already exsits on playlsit 
                        //throw exception to stop OLTP proccessing 
                        //this exaple will demonastrad bussiness rule exception
                        reasons.Add("Track already exists on the playlist");
                    }               
                }
                //part Two

                //check if any errors were found
                if (reasons.Count > 0)
                {
                    // issue a BusinessRuleException 
                    // A BusinessRuleException is an object
                    //that has been desinged to hold
                    //multiple errors

                    throw new BusinessRuleException("Adding track to playlist", reasons);
                }
                else
                {


                    //add the track to the playlistrack
                    newTrack = new PlaylistTrack();
                    newTrack.TrackNumber = tracknumber;
                    newTrack.TrackId = trackid;

                    //what the about foreing key to the playlist?
                    //parant entity has been setup with a Hashset
                    //Therefor, if you add a child via the navigational property the Hashset will take care of filling the forieng keys with 
                    // the approprite pkey value 

                    // add the new track to the playlist using the navigational property
                    exists.PlaylistTracks.Add(newTrack);

                    //physically place the records on the database and commit the tracnscation (using) with .SaveChanges
                    context.SaveChanges();

                }
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                //code to go here 

            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
               //code to go here


            }
        }//eom
    }
}
