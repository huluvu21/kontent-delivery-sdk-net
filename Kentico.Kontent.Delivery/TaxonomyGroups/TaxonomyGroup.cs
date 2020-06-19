﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Kentico.Kontent.Delivery.Abstractions;
using Newtonsoft.Json.Linq;

namespace Kentico.Kontent.Delivery.TaxonomyGroups
{
    /// <inheritdoc/>
    [DebuggerDisplay("Name = {" + nameof(System) + "." + nameof(IContentTypeSystemAttributes.Name) + "}")]
    public sealed class TaxonomyGroup : ITaxonomyGroup
    {
        private readonly JToken _source;
        private TaxonomyGroupSystemAttributes _system;
        private IReadOnlyList<TaxonomyTermDetails> _terms;

        /// <inheritdoc/>
        public ITaxonomyGroupSystemAttributes System
            => _system ??= _source["system"].ToObject<TaxonomyGroupSystemAttributes>();

        /// <inheritdoc/>
        public IReadOnlyList<ITaxonomyTermDetails> Terms
            => _terms ??= _source["terms"].Select(term => new TaxonomyTermDetails(term)).ToList().AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxonomyGroup"/> class with the specified JSON data.
        /// </summary>
        /// <param name="source">The JSON data to deserialize.</param>
        internal TaxonomyGroup(JToken source)
        {
            _source = source;
        }
    }
}