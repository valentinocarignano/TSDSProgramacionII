﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CEntidades.Entities
{
    public class EntityBase
    {
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = null;
    }
}
