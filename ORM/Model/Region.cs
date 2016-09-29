using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Model
{
    [Table(Name = "Region")]
    class Region
    {
        [PrimaryKey, Identity]
        [Column(Name = "RegionID")]
        public int ID { get; set; }

        [Column(Name = "RegionDescription")]
        public string Description { get; set; }

        [NotColumn]
        [Association(ThisKey = "ID", OtherKey = "TerritoryID")]
        public ICollection<EmployeeTerritory> EmployeeTerritory { get; set; }
    }
}
