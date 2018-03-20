<Query Kind="Expression">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Aggregrates
//.Count(), .Sum(), .Min(), Max()

//Aggregrates work on collections *********

//List all albums showing the album title, album artist name, 
//and the number of tracks on the album.

//using navigational properties
//  x (is the current instance of table).Artist (navigational property).Attribute
from x in Albums
select new
{
	Title = x.Title,
	Artist = x.Artist.Name,
	trackcount = x.Tracks.Count()
}

//List the artists and their number of albums. 
//Order the list most albums to least.

from x in Artists
orderby x.Albums.Count() descending
select new
{
	artist = x.Name,
	albumcount = x.Albums.Count()
}

//Find the maximum number of albums for all artists

//the from will create a list of counts, one for each artist
//out of this list, we want the maximum value
(from x in Artists
select x.Albums.Count()).Max()

(Artists.Select(x => x.Albums.Count ())).Max()

//produce a list of albums which have tracks showing their
//title, artist, number of tracks on album, total price of all tracks,
//longest track, shortest track, and average track length

from x in Albums
where x.Tracks.Count() > 0
select new
{
	title = x.Title,
	artistname = x.Artist.Name,
	methodnumberoftracks = x.Tracks.Count(),
	querynumberoftracks = (from y in x.Tracks
						   select y).Count(),
	totaltrackcost = x.Tracks.Sum(tr => tr.UnitPrice),
	longest = x.Tracks.Max(tr => tr.Milliseconds),
	shortest = x.Tracks.Min(tr => tr.Milliseconds),
	averagelength = x.Tracks.Average(tr => tr.Milliseconds)
}

//List all the Playlist which have a track showing the
//playlist name, number of tracks on the playlist, the cost 
//of the playlist, and total storage size for the playlist.

from pl in Playlists
where pl.PlaylistTracks.Count() > 0
select new
{
	name = pl.Name,
	trackcount = pl.PlaylistTracks.Count(),
	cost = pl.PlaylistTracks.Sum(pltr => pltr.Track.UnitPrice),
	storage = pl.PlaylistTracks.Sum(pltr => pltr.Track.Bytes/1000.0)
}

//list all sales support employees showing their fullname (lastname, firstname),
//their title and the number of customers each supports. Order by fullname

from x in Employees
where x.Title.Contains("Support")
orderby x.LastName, x.FirstName
select new
{
	Name = x.LastName + ", " + x.FirstName,
	title = x.Title,
	ClientCount = x.SupportRepIdCustomers.Count()
}












