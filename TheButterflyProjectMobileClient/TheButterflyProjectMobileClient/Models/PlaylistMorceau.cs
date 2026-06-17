using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Models
{
    public class PlaylistMorceau : OfflineClientEntity
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

        public string PlaylistId { get; set; }
        //public Playlist Playlist { get; set; } = null!;

        public string MorceauId { get; set; }
        //public Morceau Morceau { get; set; } = null!;

        public int Order { get; set; }
    }
}
