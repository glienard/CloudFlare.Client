﻿using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Client.Zones
{
    /// <inheritdoc />
    public class ZoneSettings : ApiContextBase<IConnection>, IZoneSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneSettings"/> class
        /// </summary>
        /// <param name="connection">Connection settings</param>
        public ZoneSettings(IConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<ZoneSetting>> GetAlwaysUseHttpsSettingAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}";
            return await Connection.GetAsync<ZoneSetting>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<ZoneSetting>> UpdateAlwaysUseHttpsSettingAsync(string zoneId, ZoneSetting status, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}";
            return await Connection.PatchAsync(requestUri, status, cancellationToken).ConfigureAwait(false);
        }
    }
}