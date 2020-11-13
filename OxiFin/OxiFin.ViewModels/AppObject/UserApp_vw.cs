namespace OxiFin.ViewModels.AppObjects
{
    public class UserApp_vw : EntityBase_vw<long>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }       
    }

    public class Login_vw : EntityBase_vw<long>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLogged : EntityBase_vw<long>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string Token { get; set; }
    }
}
