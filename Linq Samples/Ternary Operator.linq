<Query Kind="Statements">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//ternary operator  condition(s)? true value : false value

var results1 = from albumRow in Albums
				orderby albumRow.ReleaseLabel
				select new
				{
					title = albumRow.Title,
					label = albumRow.ReleaseLabel == null? "Unknown"
									:albumRow.ReleaseLabel
				};
results1.Dump();

var results2 = from albumRow in Albums
	select new
	{
		title = albumRow.Title,
		decade = albumRow.ReleaseYear > 1969 && albumRow.ReleaseYear < 1980? "70s" :
				 (albumRow.ReleaseYear > 1979 && albumRow.ReleaseYear < 1990? "80s" :
				  (albumRow.ReleaseYear > 1989 && albumRow.ReleaseYear < 2000? "90s" :
				    "Modern"))
	};
results2.Dump();

var resultavg = (from trackRow in Tracks
                 select trackRow.Milliseconds).Average();

var results3 = from x in Tracks
			   select new
	{
		Song = x.Name,
		Length = x.Milliseconds > resultavg ? "Long" :
		         x.Milliseconds < resultavg ? "Short" :
				 "Average"
	};
results3.Dump();
	
				 














