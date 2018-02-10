<Query Kind="Expression">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Grouping
//going from child to parent
//grouing of data within itself 
//a) by column
//b) by multiple columns
//c) by an entity


//grouping can be save temprory into dataset and that dataset can be reported for


//the grouping attributes is refer to as .key
//multiple attributes or entity uses .key .attribute




//report albums by ReleaseYear

from x in Albums
group x  by x.ReleaseYear into gYear
select gYear 


from x in Albums
group x  by x.ReleaseYear into gYear
select new 
{
      year = gYear.Key,
	  numberOfAlbumforyear= gYear.Count(),
	  Albumandartist = from y in gYear
	               select new
	               {
				     title = y.Title,
					 artist = y.Artist.Name,
					 NumberOftracks = ( from p in y.Tracks
					             select p).Count()
				   }
}

//grouping of tracks by Name
//actions against your data BEFORE gouping 
// is done against the natural entity attributes
// actions done AFTER goroping must refer to temprary group dataset
from t in Tracks 
where t.Album.ReleaseYear >2010
group t by t.Genre.Name into gTemp
orderby gTemp.Count() descending 
select new 
{
  genre = gTemp.Key,
  numberOf = gTemp.Count()
}


//grouping can be done agaisnt intire entity

from t in Tracks 
where t.Album.ReleaseYear >2010
group t by t.Genre into gTemp
orderby gTemp.Count() descending 
select new 
{
  genre = gTemp.Key.Name,
  numberOf = gTemp.Count()
}
//// 

from c in Customers
where c.LastName.Contains("ch")
group c by c.SupportRepIdEmployee into gTemp

select new 
{
   employee = gTemp.Key.LastName + "," + gTemp.Key.FirstName +"(" +gTemp.Key.Phone +")",
   customerCount = gTemp.Count(),
   Customers= (from y in gTemp
     orderby y.State,y.City,y.LastName
           select new 
	        {
			 fullname= y.LastName + "," +y.FirstName,
			 city =  y.City,
			 state = y.State
			}) 
}

//joins can be used where navigational properties do not exist
//join can be used between assoiccate entities
// scenario pkey ==fkey


// leftside of the join should be the support data
// right side of the join is the record collection to be processed


from xRightSide in Artists
join yLeftSide in Albums
on xRightSide.ArtistId equals yLeftSide.ArtistId

select new 
{
  title = yLeftSide.Title,
  year = yLeftSide.ReleaseLabel ==null ? "Unknown" : yLeftSide.ReleaseLabel,
  artist = xRightSide.Name,
  trackcount = yLeftSide.Tracks.Count()
}






