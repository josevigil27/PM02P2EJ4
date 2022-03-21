using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM02P2EJ4.Models
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Uri { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
