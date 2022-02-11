using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zo_organized.Shared
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Method)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
