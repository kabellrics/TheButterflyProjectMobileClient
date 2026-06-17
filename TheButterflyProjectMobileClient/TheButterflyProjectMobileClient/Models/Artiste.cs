using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Models
{
    public class Artiste : OfflineClientEntity
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
        public string? CoverEtag { get; set; }
        public string? Fanart { get; set; }
        public string? FanartEtag { get; set; }
        // Relation many-to-many via table de liaison
        public ICollection<ArtisteMorceau> ArtisteMorceaux { get; set; } = new List<ArtisteMorceau>();

        #region LocalData
        [NotMapped]
        public string CoverLocalPath { get; set; }
        public bool IsCoverLocal => !string.IsNullOrWhiteSpace(CoverLocalPath) && File.Exists(CoverLocalPath);
        [NotMapped]
        public string FanartLocalPath { get; set; }
        public bool IsFanartLocal => !string.IsNullOrWhiteSpace(FanartLocalPath) && File.Exists(FanartLocalPath);
        #endregion
    }
}
