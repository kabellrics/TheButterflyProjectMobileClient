using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Models
{
    public class TodoItem : OfflineClientEntity
    {
        #region OfflineClientEntity
        public string Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte[] Version { get; set; }
        public bool Deleted { get; set; }
        public bool IsDirty { get; set; }
        public bool IsNew { get; set; }
        #endregion

        public string Value { get; set; }
        public bool IsChecked { get; set; }
        public string TodoListId { get; set; }
    }
}
