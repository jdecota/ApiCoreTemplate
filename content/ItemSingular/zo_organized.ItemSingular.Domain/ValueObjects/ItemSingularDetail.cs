using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zo_organized.Shared;

namespace zo_organized.ItemSingular.Domain.ValueObjects
{
    public class ItemSingularDetail : BaseValueObject
    {
        public Guid ItemSingularId { get; set; }

        public string ItemSingularName { get; set; }

        public string Description { get; set; }

        public string ItemSingularNickname { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool IsActive { get; set; }
    }
}
