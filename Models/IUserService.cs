using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleworkerservice.Models
{
    internal interface IUserService
    {
        public abstract List<User> ExecuteService();

    }
}
