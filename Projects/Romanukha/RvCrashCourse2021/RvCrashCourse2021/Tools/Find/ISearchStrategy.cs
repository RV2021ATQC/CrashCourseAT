using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crashCourse2021.Tools.Find
{
    public interface ISearchStrategy : ISearch
    {
        void SetImplicitStrategy();

        void SetExplicitStrategy();
    }

}
