﻿using Kentico.Kontent.Delivery.Abstractions;

namespace Kentico.Kontent.Delivery.ContentLinks
{
    internal class DefaultContentLinkUrlResolver : IContentLinkUrlResolver
    {
        public string ResolveLinkUrl(ContentLink link) 
            => null;

        public string ResolveBrokenLinkUrl()
            => null;
    }
}
