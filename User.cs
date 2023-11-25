using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LINQ_to_Entities_191123_FromSqlRaw
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
