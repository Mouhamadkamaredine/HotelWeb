namespace HotelBackWebApi.Models
{
    public class CreateHotelInfoInput
    {
        public int Id { get; set; }

        public string Descreption { get; set; }
        public string AboutUs { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string phone2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CopyRight { get; set; }
    }
}
