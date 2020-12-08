using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Relation : IRelation
    {
        public DateTime Date { get; set; }
        public Relation(IRelation relation)
        {
            Date = relation.Date;
        }
        public Relation(DateTime date)
        {
            Date = date;
        }
        public Relation() { }
    }
}
