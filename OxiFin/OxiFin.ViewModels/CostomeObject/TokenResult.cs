using OxiFin.ViewModels.AppObjects;
using System;

namespace OxiFin.ViewModels.AppObject
{
    public class TokenResult 
    {
        public string Value { get; set; }
        public UserLogged User { get; set; }
        public DateTime Expires { get; set; }
    }
}
