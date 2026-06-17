using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Models
{
    public class Morceau : OfflineClientEntity
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


        public string Titre { get; set; }
        public string Path { get; set; }
        public TimeSpan Duration { get; set; }
        public int Piste { get; set; }
        public string AlbumId { get; set; }

        #region LocalData
        [NotMapped]
        public string LocalPath { get; set; }
        public bool IsLocal => !string.IsNullOrWhiteSpace(LocalPath) && File.Exists(LocalPath);
        #endregion
    }
}
