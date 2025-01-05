using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Contracts.Shared
{
    public class CustomerDto
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        private CustomerDto()
        {
            Id = Guid.Empty;
            Name = string.Empty;
        }

        public CustomerDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
