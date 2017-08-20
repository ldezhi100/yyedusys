using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Edu.Sys.Comm.RequestModel
{
    public class RequestModelBase<T>
    {

        public T SearchCondition { get; set; }


        private int _start;

        public int start
        {
            get; set;
        }

        public int length { get; set; }

    }
}
