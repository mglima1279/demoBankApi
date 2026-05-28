namespace demoBankApi.DTOs
{
    public class UserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty; 
        public string Tel { get; set; } = string.Empty;

        public UserRequest() { }

        public UserRequest(string username, string password, string cpf, string tel)
        {
            Username = username;
            Password = password;
            Cpf = cpf;
            Tel = tel;
        }
    }
}
