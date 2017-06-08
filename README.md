# Mobile_App_Howest


* APIDataGetRepository
-----------------------
This class gets all data from the API


returns a list of buildings frm the api
- public async Task<List<Building>> GetBuildingList()

gets a list of campus from the api
- public async Task<List<Campus>> GetCampusList()

gets a list of floors from the api
- public async Task<List<Floor>> GetFloorList()
- public async Task<List<Floor>> GetFloorList(FloorFilter ff)

gets a list of rooms from the api
- public async Task<List<Room>> GetRoomList()
- public async Task<List<Room>> GetRoomList(RoomFilter rf)

Gets a list of forums from api
- public async Task<List<Forum>> GetForumList()

Gets a list of categorys
- public async Task<List<Category>> GetCategories()

Gets a list of hardcoded categorys, including their subCategorys
- public static List<Category> GetHardCodedCategoryList()


* MediaPicker
-----------------------
this class is used to get a picture or video from the device's camera or gallary.


opens the camera and returns a MediaFile when a picture is taken, or returns null of no picture is taken
- public static async Task<MediaFile> TakePhoto()

opens the debice's gallary and returns the photo the user has selected as MediaFile
- public static async Task<MediaFile> PickPhoto()

converts a MediaFile to a Byte Array
- public static byte[] MediaFileToByteArr(MediaFile mediafile)

* MediaPicker
-----------------------
this class is used to get gps location and handle distance calculations


gets the users location, this method can take some time
- public static async Task<double[]> GetLocation()

gets the distances between the current location and the campusses, use this method before using GetClosestCampus
- public static void GetCampusDistances(List<Campus> campusList, double[] currentLatLong)

calculate distance between 2 points
- private static double CalculateDistance(double[] latLong1, double[] latLong2)

returns the closest campus if it is closer then "minDistance"
- public static Campus GetClosestCampus(List<Campus> campuslist, double[] myLatLong, double minDistance)



* flow van ticketobject
-----------------------
Ticket object is created via TicketRepos.cs
The ticket object is created after the user is logged in, and then passed to the next windows.
on the send window the final data of the ticket gets added once the user clicks send
atachments are added to the alreasy existing ticket when the user selects an atachment.

The Ticket object is only created and modifyd with the TicketRepos class.
