using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime ModifyDate { get; set; } = DateTime.Now;
    }
}
