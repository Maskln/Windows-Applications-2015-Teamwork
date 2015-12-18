using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoApp.Attributes
{
   public class User
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string UserName { get; set; }

        public int Token { get; set; }
    }
}
