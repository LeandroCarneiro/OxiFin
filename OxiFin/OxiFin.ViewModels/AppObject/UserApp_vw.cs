namespace OxiFin.ViewModels.AppObjects
{
    public class UserApp_vw : EntityBase_vw<long>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }       
    }

    public class Login_vw
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
