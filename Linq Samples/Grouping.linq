<Query Kind="Expression">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//grouping of data within itself
//a) by a column
//b) by multiple columns
//c) by an entity

//grouping can be save temporarily into
//    a dataset and that dataset
//    can be report for

//the grouping attribute is referred to as the .Key
//multiple attributes or entity uses .Key.attribute

//report albums by ReleaseYear
from x in Albums
group x  by x.ReleaseYear into gYear
select gYear


from x in Albums
group x  by x.ReleaseYear into gYear
select new 
{
		year = gYear.Key,
		numberofalbumsforyear = gYear.Count(),
		albumandartists = from y in gYear
						 select new
							{
							  title = y.Title,
							  artist = y.Artist.Name,
							  numberoftracks = (from p in y.Tracks
							  					select p).Count()
							}
}

//grouping of tracks by Genre Name
//actions against your data BEFORE grouping
//   is done against the natural entity attributes
//actions done AFTER grouping MUST refer to the
//   temporary group dataset
from t in Tracks
where t.Album.ReleaseYear > 2010
group t by t.Genre.Name into gTemp
orderby gTemp.Count() descending
select new
{
	genre = gTemp.Key,
	numberof = gTemp.Count()
}

//grouping can be done against an entire entity

from t in Tracks
where t.Album.ReleaseYear > 2010
group t by t.Genre into gTemp
orderby gTemp.Count() descending
select new
{
	genre = gTemp.Key.Name,
	numberof = gTemp.Count()
}

from c in Customers
where c.LastName.Contains("ch")
group c by c.SupportRepIdEmployee into gTemp
select new
{
	employee = gTemp.Key.LastName + ", " + gTemp.Key.FirstName + " (" + gTemp.Key.Phone + ")",
	customerCount = gTemp.Count(),
	customers = from x in gTemp
				orderby x.State, x.City, x.LastName
				select new
				{
					name = x.LastName + ", " + x.FirstName,
					city = x.City,
					state = x.State
				}
}













