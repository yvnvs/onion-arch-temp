using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Wrappers
{
    public class ServiceResponse<T>: BaseResponse
    {
        public T Value { get; set; }
        public ServiceResponse(T value)
        {
            Value = value;
        }


    }
}
