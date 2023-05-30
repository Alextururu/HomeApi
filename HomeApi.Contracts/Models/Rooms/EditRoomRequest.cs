namespace HomeApi.Contracts.Models.Rooms
{
    public class EditRoomRequest
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public bool GasConnected { get; set; }
        public int Voltage { get; set; }
    }
}