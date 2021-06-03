namespace IC_June2020
{
    public class User
    {

        public static string AccessLevel { get; set; }
        public User() { }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string email { get; set; }
        public string password { get; set; }

    }
}
