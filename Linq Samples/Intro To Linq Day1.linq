<Query Kind="Expression">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//using query syntax, list all the records from the entity Albums
from albumRow in Albums
select albumRow

//using method syntax, list all the records from the entity Albums
Albums.Select(albumRow => albumRow)

//list all records from the entity Albums ordered by ascending ReleaseYear
from albumRow in Albums
orderby albumRow.ReleaseYear
select albumRow

Albums.OrderBy(albumRow => albumRow.ReleaseYear).Select(albumRow => albumRow)

//list all records from the entity Albums ordered by descending ReleaseYear
// then ascending Title
from albumRow in Albums
orderby albumRow.ReleaseYear descending, albumRow.Title
select albumRow

Albums
   .OrderByDescending (albumRow => albumRow.ReleaseYear)
   .ThenBy (albumRow => albumRow.Title)
   .Select(albumRow => albumRow)
   
//the where clause does filtering on your collection
//list all records from the entity Albums ordered by descending ReleaseYear
// then ascending Title for albums bewtween 2007 and 2010
from albumRow in Albums
where albumRow.ReleaseYear >= 2007 &&
      albumRow.ReleaseYear <= 2010
orderby albumRow.ReleaseYear descending, albumRow.Title
select albumRow

Albums
   .Where (albumRow => ((albumRow.ReleaseYear >= 2007) && (albumRow.ReleaseYear <= 2010)))
   .OrderByDescending (albumRow => albumRow.ReleaseYear)
   .ThenBy (albumRow => albumRow.Title)
   .Select(albumRow => albumRow)
   
//list all customers in alphabetic order by last name, firstname who live in
//the USA.
from c in Customers
where c.Country.Equals("USA")
orderby c.LastName, c.FirstName
select c

//selected columns

//list all customers in alphabetic order by last name who 
//have a yahoo email. show only the customer full name (lastname, firstName)
//and their email
from c in Customers
where c.Email.Contains("yahoo")
orderby c.LastName
select new
{
	FullName = c.LastName + ", " + c.FirstName,
	Email = c.Email
}
   
//Create an alphabetic list of albums showing album title, releaseyear 
//artist
from a in Albums
orderby a.Title
select new
{
	Title = a.Title,
	Year = a.ReleaseYear,
	Artist = a.Artist.Name  //naviagtional property
}

//list the albums for U2, showing title and releaseyear
from a in Albums
where a.Artist.Name.Contains("U2")
orderby a.Title
select new
{
	Title = a.Title,
	Year = a.ReleaseYear
}











   
   
   
   