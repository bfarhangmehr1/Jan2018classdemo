<Query Kind="Program">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	// to comment Ctrl+K,Ctrl+C
	// to uncomment Ctrl+K,Ctrl+U
	
	
	//List all sales support employees showing their fullname (lastname, firstname),
	//their title and the number of customers each supports. Order by fullname.
	//In additional show a list of the customers for each employee.
	
	//to accomplish the list of customers, we will use a nested query
	//the data source for the list of customers will be the x collection
	// x represents a single employee that is currently being processed
	// x.navigationproperty will point to the current children belonging
	//   to the x record
	
	//from employeeRow in Employees
	//where employeeRow.Title.Contains("Support")
	//orderby employeeRow.LastName, employeeRow.FirstName
	//select new
	//{
	//	Name = employeeRow.LastName + ", " + employeeRow.FirstName,
	//	//title = employeeRow.Title,
	//	ClientCount = employeeRow.SupportRepIdCustomers.Count(),
	//	ClientList = from customerRowOfemployeeRow in employeeRow.SupportRepIdCustomers
	//					orderby customerRowOfemployeeRow.LastName, 
	//								customerRowOfemployeeRow.FirstName
	//					select new
	//							{
	//								Client = customerRowOfemployeeRow.LastName + ", " + 
	//											customerRowOfemployeeRow.FirstName,
	//								Phone = customerRowOfemployeeRow.Phone
	//							}
	//}
	
	//Create a list of albums showing its title and artist.
	//Show albums with 5 or more tracks only.
	//Show the songs on the album (name and length)
	
	//the nested query is return as an IEnumerable<T> or IQueryable<T>
	//if you need to return your query as an List<T> then you must
	//    encapulate your quer and add .ToList()
	//    (from ....).ToList()
	
	//ToList() is useful if you require your data to be in memory
	//    for some execution
	
	//from x in Albums
	//where x.Tracks.Count() >= 25
	//select new
	//{
	//	title = x.Title,
	//	artist = x.Artist.Name,
	//	songs = (from y  in x.Tracks
	//			select new
	//			{
	//				songtitle = y.Name,
	//				length = y.Milliseconds/60000 + ":" + 
	//							(y.Milliseconds%60000)/1000
	//			}).ToList()
	//}
	
	//List the playlists with more than 15 tracks.
	//show the playlist name, and list of tracks.
	//for each track show the song name, and Genre
	
	var trackcountlimit = 15;  //could be an input parameter
	
	//use of a "parameter value" on your query
	
	var results = from x in Playlists
				where x.PlaylistTracks.Count() > trackcountlimit
				select new ClientPlaylist
				{
					playlist = x.Name,
					songs = (from y in x.PlaylistTracks
							select new TracksAndGenre
							{
								songtitle = y.Track.Name,
								songgenre = y.Track.Genre.Name,
							}).ToList()
				};
	results.Dump();

}

// Define other methods and classes here

//the query requires 2 class definitions
//the query in NOT able to use the Entity classes
//the query has 2 new datasets
//the nested query is a flat non-structured dataset
//the top query has a structure of primative field(s)
//     and List<T> of records

//the flat non-structured dataset can be created as
//  a POCO class

//the structures dataset will be created as a DTO class

//an Entity class scope is a complete definition of a 
//   single database table

//POCO scope : flat, not an entity
public class TracksAndGenre
{
	public string songtitle {get;set;}
	public string songgenre {get;set;}
}

//DTO scope : internal structure

public class ClientPlaylist
{
	public string playlist {get;set;}
	public List<TracksAndGenre> songs{get;set;}
}