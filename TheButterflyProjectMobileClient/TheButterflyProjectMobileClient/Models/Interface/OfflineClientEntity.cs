using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheButterflyProjectMobileClient.Models.Interface
{
    public interface OfflineClientEntity
    {
        [Key]
        public string Id
        {
            get; set;
        }
        public DateTimeOffset? UpdatedAt
        {
            get; set;
        }
        public DateTime? UpdatedDate
        {
            get; set;
        }
        public byte[] Version
        {
            get; set;
        }
        public bool Deleted
        {
            get; set;
        }
        bool IsDirty
        {
            get; set;
        }
        public bool IsNew
        {
            get; set;
        }
    }
}
