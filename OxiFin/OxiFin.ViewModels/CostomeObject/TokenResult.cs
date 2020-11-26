using OxiFin.ViewModels.AppObjects;
using System;

namespace OxiFin.ViewModels.AppObject
{
    public class TokenResult 
    {
        public string Value { get; set; }
        public UserApp_vw User { get; set; }
        public DateTime Expires { get; set; }
    }
}
