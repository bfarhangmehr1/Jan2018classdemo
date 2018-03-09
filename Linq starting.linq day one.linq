<Query Kind="Expression">
  <Connection>
    <ID>3113dd55-cf0d-4c6d-b341-15e047a4fd04</ID>
    <Persist>true</Persist>
    <Server>WA322-16</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

// list using query syntax. list all the records from the entity Albums

from albumRow in Albums 
select albumRow

// list using method syntax. list all the records from the entity Albums
Albums.Select(albumRow => albumRow)


Albums.OrderBy(albumRow => albumRow.ReleaseYear).Select(albumRow => albumRow)


// list all records  from the entity Albums ordered by a=descending ReleaseYear
// then ascending Title
// query 
from albumRow in Albums 
orderby albumRow.ReleaseYear descending, albumRow.Title
select albumRow


//method
Albums
   .OrderByDescending (albumRow => albumRow.ReleaseYear)
   .ThenBy (albumRow => albumRow.Title)
   .select(albumRow => albumRow)

//the where clause does filtering on your collection 
// list all records  from the entity Albums ordered by descending ReleaseYear
// then ascending Title for albums between 2000 and 2010

from albumRow in Albums 
where albumRow.ReleaseYear >= 2007 && 
   albumRow.ReleaseYear <= 2010
orderby albumRow.ReleaseYear descending, albumRow.Title
select albumRow

//method
Albums
   .Where (albumRow => ((albumRow.ReleaseYear >= 2007) && (albumRow.ReleaseYear <= 2010)))
   .OrderByDescending (albumRow => albumRow.ReleaseYear)
   .ThenBy (albumRow => albumRow.Title)
   
   // list all customer in alphabetic order by last name, firstname, who live in the USA.
from customerRow in Customers 
where customerRow.Country.Equals("USA")
orderby customerRow.FirstName , customerRow.LastName 
select customerRow


// method
Customers
   .Where (customerRow => customerRow.Country.Equals ("USA"))
   .OrderBy (customerRow => customerRow.FirstName)
   .ThenBy (customerRow => customerRow.LastName)  
   
   
   // selected coulumn (using Poco)   
 // list all customer in alphabetic order by last name  who have aol email show only customer full name and their email
 from customerRow in Customers 
where customerRow.Email.Contains("yahoo")
orderby  customerRow.LastName 
select new
{
  FullName = customerRow.LastName + "," +customerRow.FirstName,
  Email= customerRow.Email
}

// create an alphabetic list of albums showing album, title , releasyear and artist
from albumRow in Albums
orderby albumRow.Title
select new
{
   Title= albumRow.Title ,
   ReleaseYear= albumRow.ReleaseYear ,
   Artist = albumRow.Artist.Name  // navigational property 
}

 //list the albums for U2, showing title and releaseYear
 
from albumRow in Albums
orderby albumRow.Title
where albumRow.Artist.Name.Contains("U2")
select new
{
   Title= albumRow.Title ,
   ReleaseYear= albumRow.ReleaseYear
  
}