using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int Id { get; set; }

        [Required]
        public string Book { get; set; } // Scripture Book

        [Required]
        public string BookAndChapter { get; set; } // Book of (e.g., Book of Mormon)

        [Required]
        public string Verse { get; set; } // Verse

        public string Notes { get; set; } // Notes of impression or study

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } // Date when the entry was added
    }
}
