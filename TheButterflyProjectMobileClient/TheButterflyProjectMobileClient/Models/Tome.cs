using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.Models
{
    public class Tome : OfflineClientEntity
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
        public string? CoverPath { get; set; }
        public string? CoverEtag { get; set; }
        public string? CFI_Epub { get; set; }
        public int Numero { get; set; }
        public int CurrentPage
        {
            get; set;
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReadingStatus ReadingStatus
        {
            get; set;
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TomeType TomeType { get; set; }
        public bool IsFavorite { get; set; }

        public string SerieId { get; set; }

        #region LocalData
        [NotMapped]
        public string CoverLocalPath { get; set; }
        public bool IsCoverLocal => !string.IsNullOrWhiteSpace(CoverLocalPath) && File.Exists(CoverLocalPath);
        [NotMapped]
        public string LocalPath { get; set; }
        public bool IsLocal => !string.IsNullOrWhiteSpace(LocalPath) && File.Exists(LocalPath);
        #endregion
    }
}
