<Query Kind="Expression">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//joins can be used where navigational properties DO NOT exist
//joins can be used between associate entities
//scenario pkey == fkey

//left side of the join should be the support data
//right side of the join is the record collection to be processed
from xRightSide in Artists
join yLeftSide in Albums
on xRightSide.ArtistId equals yLeftSide.ArtistId
select new
{
   title = yLeftSide.Title,
   year = yLeftSide.ReleaseYear,
   label = yLeftSide.ReleaseLabel == null ? "Unknown" : y.ReleaseLabel,
   artist = xRightSide.Name,
   trackcount = yLeftSide.Tracks.Count()
}