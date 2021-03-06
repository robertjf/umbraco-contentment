﻿/* Copyright © 2020 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Community.Contentment.DataEditors
{
    [Core.Composing.HideFromTypeFinder]
    public sealed class CountriesDataSource : IDataListSource
    {
        public string Name => ".NET ISO 3166 Countries";

        public string Description => "Data source for all the countries.";

        public string Icon => "icon-globe-inverted-europe-africa";

        public IEnumerable<ConfigurationField> Fields => default;

        public Dictionary<string, object> DefaultValues => default;

        public IEnumerable<DataListItem> GetItems(Dictionary<string, object> config)
        {
            return CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .Select(x => new RegionInfo(x.Name))
                .DistinctBy(x => x.DisplayName)
                .OrderBy(x => x.DisplayName)
                .Select(x => new DataListItem
                {
                    Name = x.DisplayName,
                    Value = x.TwoLetterISORegionName
                });
        }
    }
}
