using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheButterflyProjectMobileClient.Models.Interface
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();

        public int? Count
        {
            get; set;
        }

        public string? NextLink
        {
            get; set;
        }
    }
}
