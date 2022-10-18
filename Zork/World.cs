using System.Runtime.Serialization;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Zork
{
    public class World
    {
        public HashSet<Room> Rooms { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<string, Room> RoomsByName => mRoomsByName;


        public Player SpawnPlayer() => new Player(this, StartingLocation);

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            mRoomsByName = Rooms.ToDictionary(room => room.Name, room => room);
            foreach (Room room in Rooms)
            {
                room.UpdateNeighbors(this);
                
            }
            
        }

        [JsonProperty]
        private string StartingLocation { get; set; }

        private Dictionary<string, Room> mRoomsByName;



        //public Room[] Rooms { get; }

        //public Dictionary<string, Room> RoomsByName { get; }

       // public World(Room[] rooms)
       // {
        //    Rooms = rooms;
        //}

      
    }
}
