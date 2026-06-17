using System;
using System.Collections.Generic;

namespace TheButterflyProjectMobileClient.Models
{
    public static class EnumContainer
    {
        public static IReadOnlyList<ReadingStatus> ReadingStatuses { get; } = Enum.GetValues<ReadingStatus>();

        public static IReadOnlyList<TomeType> TomeTypes { get; } = Enum.GetValues<TomeType>();

        public static IReadOnlyList<AppSettingKey> AppSettingKeys { get; } = Enum.GetValues<AppSettingKey>();

        public static IReadOnlyList<ItemType> ItemTypes { get; } = Enum.GetValues<ItemType>();

        public static IReadOnlyList<ItemOrderType> ItemOrderTypes { get; } = Enum.GetValues<ItemOrderType>();
    }
    public enum ReadingStatus
    {
        NonLu,
        EnCours,
        Lu
    }
    public enum TomeType
    {
        BD,
        Livre,
        PDF,
        Inconnu
    }
    public enum AppSettingKey
    {
        AssetFolderPath = 2,
        TempFolderForExtractedCover = 3,
        ExtensionToFind = 4,
        Theme = 5,
        CoverExtension = 6,
        GoogleBookToken = 7,
        DeezerUserId = 8
    }
    public enum ItemType
    {
        Collection,
        Serie,
        Tome,
        Navigation
    }
    public enum ItemOrderType
    {
        ByName,
        ByOrder
    }
}
