using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    // Enum para limitar los roles exactos que pide el PDF 
    public enum UserRole
    {
        HumanResources,
        AdminStaff,
        ItSupport,
        Nurse,
        Doctor
    }

    public class User : Person
    {
        public string Username { get; set; }
        public string Password { get; set; } // En la vida real esto se encripta
        public UserRole Role { get; set; }

        // Constructor para obligar a tener datos mínimos
        public User(string id, string name, string username, string password, UserRole role)
        {
            Id = id;
            FullName = name;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
