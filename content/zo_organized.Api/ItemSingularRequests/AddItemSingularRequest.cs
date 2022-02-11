namespace zo_organized.Api.ItemSingularRequests
{
    public class AddItemSingularRequest
    {
        public string ItemSingularName { get; set; }

        public string Description { get; set; }

        public string ItemSingularNickname { get; set; }

        public bool IsActive { get; set; }
    }
}
