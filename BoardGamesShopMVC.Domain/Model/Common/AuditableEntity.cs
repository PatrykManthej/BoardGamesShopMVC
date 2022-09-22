using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Domain.Model.Common
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public int StatusId { get; set; }
        public DateTime? Inactivated { get; set; }
    }
}
