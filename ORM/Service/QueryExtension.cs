using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using ORM.Model;

namespace ORM.Service
{
    static class QueryExtension
    {
        [ExpressionMethod("RegionsImpl")]
        public static IEnumerable<Region> GetRegions(this Employee employee)
        {
            return RegionsImpl().Compile()(employee);
        }

        [ExpressionMethod("EmployesImpl")]
        public static IEnumerable<int> GetEmployees(this Region region)
        {
            return EmployesImpl().Compile()(region);
        }
        
        static Expression<Func<Employee, IEnumerable<Region>>> RegionsImpl()
        {
            return e => e.EmployeeTerritory.Select(r => r.Region);
        }

        static Expression<Func<Region, IEnumerable<int>>> EmployesImpl()
        {
            return r => r.EmployeeTerritory.Select(e => e.EmployeeID);
        }
    }
}
