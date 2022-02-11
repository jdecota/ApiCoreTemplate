using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zo_organized.ItemSingular.Domain.Events;
using zo_organized.ItemSingular.Domain.ValueObjects;
using zo_organized.Shared;
using zo_organized.Shared.Interfaces;

namespace zo_organized.ItemSingular.Domain.Aggregates
{
    public class ItemSingularAggregate : BaseEntity, IAggregateRoot
    {
        #region IAggregate implementation

        public Guid UniqueId { get; private set; }

        public string ModelPropertyName { get; private set; }

        public string StoredProcedureName { get; private set; }

        public string DbConnectionName { get; private set; }

        #endregion

        public ItemSingularDetail ItemSingularInformation { get; private set; }

        public IEnumerable<ItemSingularDetail> ItemSingularList { get; private set; }

        public ItemSingularAggregate() { }

        public ItemSingularAggregate(string connectionName)
        {
            DbConnectionName = connectionName;
        }

        public ItemSingularAggregate GetItemSingularById(string spName, Guid ItemSingularId)
        {
            UniqueId = ItemSingularId;
            StoredProcedureName = spName;
            ModelPropertyName = "ItemSingularInformation";
            return this;
        }

        public ItemSingularAggregate AddItemSingular(string spName, string name, string description, string nickname, bool isActive = true)
        {
            ItemSingularInformation = new ItemSingularDetail
            {
                ItemSingularName = name,
                Description = description,
                ItemSingularNickname = nickname,
                IsActive = isActive
            };
            StoredProcedureName = spName;
            ModelPropertyName = "ItemSingularInformation";
            return this;
        }

        public ItemSingularAggregate GetAllItemPlural(string spName)
        {
            StoredProcedureName = spName;
            ModelPropertyName = "ItemSingularList";
            return this;
        }

        public void AddItemSingularSuccessEvent()
        {
            Events.Add(new AddItemSingularSuccessEvent(this));
        }

        public void AddGetAllItemPluralSuccessEvent()
        {
            Events.Add(new GetAllItemPluralSuccessEvent(this));
        }

        public void AddGetItemSingularByIdSuccessEvent()
        {
            Events.Add(new GetItemSingularByIdSuccessEvent(this));
        }
    }
}
