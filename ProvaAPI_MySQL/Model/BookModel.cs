using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaAPI_MySQL.Model
{
    public class BookModel
	{
        [Key]
        public int IdBook { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int? IdUser { get; set; }

    }
}

