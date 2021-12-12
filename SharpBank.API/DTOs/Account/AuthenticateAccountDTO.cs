namespace SharpBank.API.DTOs.Account
{
    public class AuthenticateAccountDTO
    {
        public Guid AccountId { get; set; }
        public string Password { get; set; }

    }
}
