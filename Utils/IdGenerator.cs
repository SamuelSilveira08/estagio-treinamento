using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class IdGenerator
    {
        public string Id { get; }

        public IdGenerator()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
