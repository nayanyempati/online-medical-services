namespace online_medical_services.Models
{
    public class TokenResponseModel
    {
        public string AccessToken { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
