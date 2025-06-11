namespace ParcelService.DTO
{
    public class ParcelDTO
    {

        public int ParcelId { get; set; }
        public string TrackingNumber { get; set; }
        public int Sender { get; set; }
        public string Receiver { get; set; }
        public string Status { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
