using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace zo_organized.Shared.Interfaces
{
    public interface IBaseResponse
    {
        Guid Id { get; set; }

        DateTime Created { get; set; }

        DateTime Updated { get; set; }

        bool IsActive { get; set; }

        HttpStatusCode Status { get; set; }
    }
}
