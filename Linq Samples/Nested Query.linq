<Query Kind="Program">
  <Connection>
    <ID>c5be593d-ef5e-4c43-a753-19f9d99ce380</ID>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	
	 //list all sale supoort employees showing their fullname( lastname,firstname),
	 // their title and the number of customer each supports. Order by fullname
	 // in additin show the list of the customers for each employee
	 
	// to accomplish the list of customers we use nested query
	// the data source for the list of customers will be x collection 
	//x represent a single employee that is currently being proccessed 
	// x.navigationproperty will ponit current children belonging to x record
	
	
	
	//from employeeRow in Employees
	//orderby employeeRow.LastName + employeeRow.FirstName
	//where employeeRow.Title.Contains("Support")
	//
	//select new 
	//{
	//  fullname= employeeRow.LastName +  " ," + employeeRow.FirstName,
	//  Title= employeeRow.Title,
	//  NumberOfCustomer = employeeRow.SupportRepIdCustomers.Count(),
	//  //SupportRepIdCustomers is new (data source)
	//  clinetList = from customerRowOfemployee in employeeRow.SupportRepIdCustomers
	//               orderby customerRowOfemployee.LastName ,customerRowOfemployee.FirstName
	//			   select new 
	//	           {
	//			     Client = customerRowOfemployee.LastName + ", " +customerRowOfemployee.FirstName,
	//				 Phone= customerRowOfemployee.Phone
	//			   }
	//  
	//}
	
	
	
	//list of All of the Albums showing the  title, artist name, and list of track assinged on that album
	
	//the listed qury is return IEnumerable <T> or IQueryalbe<T>
	// if you need to rerurn your query as an list of T then you must 
	// encapulate your (query and add .Tolist())
	// (from....).Tolist()
	
	
	//To list is usefull if you require data to be in memory for some execution
	//
	from x in Albums
	where x.Tracks.Count()>= 25
	select new
	{
	   Title = x.Title,
	   ArtistName= x.Artist.Name,
	   ListOfTracks =( from y in x.Tracks
	    select new 
		      {
		         songTitle= y.Name,
				 lenght = y.Milliseconds/60000 + ":" + (y.Milliseconds%60000)/1000		 
		      }).ToList()	
	}
	
	// list the playlist with more than 8 tracks show the playlistname and list of tracks 
	// for each tracks show song name,and Genre
	
	var trackcountlimit = 15; // could be an input parameter
	
	// use of a "parameter value" on your query
	
	  var results = from x in Playlists 
	  where x.PlaylistTracks.Count()> trackcountlimit
	  select new ClientPlayList
	  {
	    playlist= x.Name,
		songs = (from y in x.PlaylistTracks
		       select new TracksAndGenre
		     {
			  songtitle = y.Track.Name,
			  songGenre = y.Track.Genre.Name
			 }).ToList()


	  };
	
  results.Dump();	

}

// Define other methods and classes here

// the query requirs 2 class definitions 
// the query is not able to use Entiteis classess
// the query has 2 new datasets 
//the nested query is a flat non-structured dataset
// the top query has the sturctre of primitive - field(s)
//  and List<T> of records

// the flat non stucturd data set can be created as 
// a POCO class 
// strucred dataset will be created as a DTO class 

//an Entity class scope is a complete definition of single database table


//POCO scope : flat, not an entity
public class TracksAndGenre
{
   public string songtitle {get;set;}
   public string songGenre {get;set;}
}

// DTO scope : internal structure

public class ClientPlayList
{
 public string playlist {get;set;}
 // this is a strucrue
 // we use list of <T> in web app if we want to list we have to put ToList() in query Inumuralbe
 public List <TracksAndGenre> songs {get;set;}
}





