using Microsoft.AspNetCore.Mvc;
using zo_organized.Api.ItemSingularEventHandlers;
using zo_organized.Api.ItemSingularRequests;
using zo_organized.ItemSingular.Domain.Aggregates;
using zo_organized.ItemSingular.Domain.Repositories;

namespace zo_organized.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ItemSingularController : ControllerBase
    {
        private readonly ILogger<ItemSingularController> _logger;

        private readonly IItemSingularRepository<ItemSingularAggregate> _repository;

        public ItemSingularController(ILogger<ItemSingularController> logger, IItemSingularRepository<ItemSingularAggregate> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("/GetAllItemPlural")]
        public async Task<IActionResult> GetAllItemPlural()
        {
            _logger.LogInformation("Get all ItemPlural operation is in progress");

            var aggregate = new ItemSingularAggregate("Dev").GetAllItemPlural("dbo.GetAllItemPlural");
            aggregate.AddDomainEventHandler(typeof(GetAllItemPluralSuccessEventHandler));
            return Ok((await _repository.GetAllItemPlural(aggregate)).ItemSingularList);
        }

        [HttpGet]
        [Route("/GetItemSingularById")]
        public async Task<IActionResult> GetItemSingularById(Guid ItemSingularId)
        {
            _logger.LogInformation("Get ItemSingular by id operation is in progress");
            if (ItemSingularId != Guid.Empty)
            {
                var aggregate = new ItemSingularAggregate("Dev").GetItemSingularById("dbo.GetItemSingularById", ItemSingularId);
                aggregate.AddDomainEventHandler(typeof(GetItemSingularByIdSuccessEventHandler));
                return Ok((await _repository.GetItemSingularById(aggregate)).ItemSingularInformation);
            }
            return BadRequest("ItemSingular id is required");
        }

        [HttpPost]
        [Route("/AddItemSingular")]
        public async Task<IActionResult> AddItemSingular(AddItemSingularRequest request)
        {
            _logger.LogInformation("Add ItemSingular operation is in progress");

            if (request != null && !string.IsNullOrEmpty(request.ItemSingularName))
            {
                var aggregate = new ItemSingularAggregate("Dev").AddItemSingular("dbo.AddItemSingular", request.ItemSingularName, request.Description, request.ItemSingularNickname, request.IsActive);
                aggregate.AddDomainEventHandler(typeof(GetItemSingularByIdSuccessEventHandler));
                return Ok((await _repository.AddItemSingular(aggregate)).ItemSingularInformation);
            }
            return BadRequest("ItemSingular name is required");
        }
    }
}
