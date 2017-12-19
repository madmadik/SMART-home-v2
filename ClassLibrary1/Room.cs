using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class Room
    {
        public string Name { get; set; }
        private List<Device> devicesInRoom;
        
        public Room()
        {
            devicesInRoom = new List<Device>();
        }
        public void AddDeviceToList(Device device)
        {
            devicesInRoom.Add(device);
        }
        public Device GetDeviceFromList(int index)
        {
            return devicesInRoom[index];
        }
        public bool isEmptyListOfDevises()
        {
            return devicesInRoom.Count == 0;    
        }
        public void DeleteDevice(int index)
        {
            devicesInRoom.Remove(devicesInRoom[index]);
        }
        public int CountOfDevisesInList()
        {
            return devicesInRoom.Count;
        }
        public List<Device> GetList()
        {
            return devicesInRoom;
        }
    }
}
