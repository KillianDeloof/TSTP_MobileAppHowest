# Mobile_App_Howest


* APIDataGetRepository
-----------------------
Deze klasse staat in om de benodigde data afkostig van Meneer Daels API op te halen

-         public async Task<List<Building>> GetBuildingList()
Dit haalt een lijst op van alle gebouwen


-        public async Task<List<Campus>> GetCampusList()
Haalt een lijst op van campussen


-        public async Task<List<Floor>> GetFloorList()
 Ophalen van de lijst van verdiepen, aangeleverd door de API.
 Hierbij wordt gebruik gemaakt van een FloorFilter.


-         public async Task<List<Room>> GetRoomList(RoomFilter rf)
 Opvragen van de lijst van rooms, aangeleverd door de API.



-         public async Task<List<Forum>> GetForumList()
Opvragen van de lijst van verschillende forums 


-         public async Task<List<Category>> GetCategories()
Opvragen van de lijst van verschillende categorieën







