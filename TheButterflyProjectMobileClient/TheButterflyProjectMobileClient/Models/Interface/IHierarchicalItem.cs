using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheButterflyProjectMobileClient.Models.Interface
{
    public interface IHierarchicalItem
    {
        public string Id
        {
            get;
        }
        public string Titre
        {
            get;
        }
        public string? CoverPath
        {
            get;
        }
        public string? FanartPath
        {
            get;
        }
        public string? ParentId
        {
            get;
        }
        public int? Level
        {
            get; set;
        }
    }
}
