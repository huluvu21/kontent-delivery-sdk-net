// This code was generated by a kontent-generators-net tool 
// (see https://github.com/Kentico/kontent-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System.Collections.Generic;
using Kentico.Kontent.Delivery.ContentItems;
using Kentico.Kontent.Delivery.ContentTypes.Element;

namespace Kentico.Kontent.Delivery.Rx.Tests.Models.ContentTypes
{
    public class HostedVideo
    {
        public const string Codename = "hosted_video";
        public const string VideoIdCodename = "video_id";
        public const string VideoHostCodename = "video_host";

        public string VideoId { get; set; }
        public IEnumerable<MultipleChoiceOption> VideoHost { get; set; }
        public ContentItemSystemAttributes System { get; set; }
    }
}