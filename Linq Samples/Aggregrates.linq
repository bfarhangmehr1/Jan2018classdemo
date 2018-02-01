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










