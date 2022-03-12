﻿using System.ComponentModel.DataAnnotations;

namespace S2021A6FH.EntityModels
{
    public class Genre
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}