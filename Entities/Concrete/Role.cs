using Core.Entittes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role:EntityBase,IEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
