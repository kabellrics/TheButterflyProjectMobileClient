using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Models
{
    public class Album : OfflineClientEntity
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

        public string Name { get; set; }
        public string? Cover { get; set; }
        public string? CoverETag { get; set; }
        public string? ArtisteId { get; set; }
        public bool IsDeezerPlaylist { get; set; }
        public string? DeezerPlaylistId { get; set; }

        #region LocalData
        [NotMapped]
        public string CoverLocalPath { get; set; }
        public bool IsCoverLocal => !string.IsNullOrWhiteSpace(CoverLocalPath) && File.Exists(CoverLocalPath);
        #endregion
    }
}
