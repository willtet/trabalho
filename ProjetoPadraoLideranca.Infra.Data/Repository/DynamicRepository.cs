using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaTsdigital.Infra.Data.Repository
{
    public class DynamicRepository : RepositoryBase<Object>
    {
        public List<Object> ListaDynamicData(string proc)
        {
            return this.GetAll(new Object(), proc).ToList();
        }

    }
}
