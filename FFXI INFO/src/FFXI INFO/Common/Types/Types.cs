
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXI_INFO.Common.Types
{

    public class _Animations
    {
        [JsonProperty(Order = 1)] public int FileID { get; init; }
        [JsonProperty(Order = 2)] public string Path { get; init; }
    }
    public class _datChunk
    {
        [JsonProperty(Order = 1)] public string Name { get; init; }
        [JsonProperty(Order = 2)] public uint Size { get; init; }
        [JsonProperty(Order = 3)] public ResourceType Type { get; init; }
        [JsonProperty(Order = 4)] public byte[] Data { get; init; }
    }
    public class _entity
    {
        [JsonProperty(Order = 1)] public string name { get; init; }
        [JsonProperty(Order = 2)] public uint serverID { get; init; }
        [JsonProperty(Order = 3)] public int targetIndex { get; init; }
        [JsonProperty(Order = 4)] public int zoneID { get; set; }
    }
    public class _dialogue
    {
        [JsonProperty(Order = 1)] public int id { get; init; }
        [JsonProperty(Order = 2)] public string text { get; init; }
    }
    public class _zones
    {
        [JsonProperty(Order = 1)] public int id { get; set; }
        [JsonProperty(Order = 2)] public string name { get; set; }
        [JsonProperty(Order = 3)] public string path { get; set; }
    }

    public class _actors
    {
        [JsonProperty(Order = 1)] public UInt32 id { get; set; }
        [JsonProperty(Order = 2)] public string name { get; set; }
        [JsonProperty(Order = 3)] public List<_events> events { get; set; } = new List<_events>();
    }
    public class _events
    {
        [JsonProperty(Order = 1)] public uint id { get; set; }
        [JsonProperty(Order = 2)] public string dialogue { get; set; }

    }

    public class _zoneRelatedInfo
    {
        [JsonProperty(Order = 1)] public int id { get; set; }
        [JsonProperty(Order = 2)] public string name { get; set; }
        [JsonProperty(Order = 3)] public string BumpMap_Dat_Path { get; set; }
        [JsonProperty(Order = 4)] public string Main_Model_Dat_Path { get; set; }
        [JsonProperty(Order = 5)] public string Shodow_Dat_Path { get; set; }
        [JsonProperty(Order = 6)] public string Entity_Dat_Path { get; set; }
        [JsonProperty(Order = 7)] public string Dialogue_Dat_Path { get; set; }
        [JsonProperty(Order = 8)] public string Event_Dat_Path { get; set; }

    }
}
