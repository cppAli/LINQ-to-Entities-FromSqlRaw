using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LINQ_to_Entities_191123_FromSqlRaw
{
    internal class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<User> Users { get; set; } = new();
    }
}
