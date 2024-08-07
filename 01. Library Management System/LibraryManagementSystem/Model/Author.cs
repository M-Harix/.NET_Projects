﻿using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
