namespace HotelBackWebApi.Models
{
    public class CreateRoom
    {
        public int ID { get; set; }
        public int RoomNb { get; set; }
        public string RoomName { get; set; }
        public string Descreption { get; set; }
        public int Cost { get; set; }
        public string BedType { get; set; }
        public int Geusts { get; set; }
        public int RoomSize { get; set; }
        public string RoomImage { get; set; }

    }
}
