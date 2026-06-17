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
    public class Collection : OfflineClientEntity
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
        public string? FanartPath { get; set; }
        public string? FanartEtag { get; set; }
        public string? ParentCollectionId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemOrderType itemOrderType { get; set; }
        //public Collection? ParentCollection { get; set; }
        public List<Collection> ChildrenCollection { get; set; } = new();
        public List<Serie> Series { get; set; } = new();
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
