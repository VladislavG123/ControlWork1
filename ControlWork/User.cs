using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
