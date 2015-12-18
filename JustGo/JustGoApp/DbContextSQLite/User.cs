﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoApp.DbContextSQLite
{
   public class User
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }

        public string ImagUri { get; set; }
    }
}
