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
    public class Serie : OfflineClientEntity
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
        public string? CoverPath { get; set; }
        public string? CoverEtag { get; set; }
        public bool IsFavorite { get; set; }
        public string? CollectionId { get; set; }
        public int? OrderInCollection { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemOrderType itemOrderType { get; set; }
        //public Collection? Collection { get; set; }

        public List<Tome> Tomes { get; set; } = new();

        #region LocalData
        [NotMapped]
        public string CoverLocalPath { get; set; }
        public bool IsCoverLocal => !string.IsNullOrWhiteSpace(CoverLocalPath) && File.Exists(CoverLocalPath);
        #endregion
    }
}
