using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Data.Models.Base
{
    public interface IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
