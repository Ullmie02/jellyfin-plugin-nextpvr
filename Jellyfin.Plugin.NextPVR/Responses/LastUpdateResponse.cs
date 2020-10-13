﻿using System.Globalization;
using System.IO;
using System;
using MediaBrowser.Controller.LiveTv;
using Microsoft.Extensions.Logging;
using MediaBrowser.Model.Serialization;
using Jellyfin.Plugin.NextPVR.Helpers;

namespace Jellyfin.Plugin.NextPVR.Responses
{
    public class LastUpdateResponse
    {
        public DateTimeOffset GetUpdateTime(Stream stream, IJsonSerializer json, ILogger<LiveTvService> logger)
        {
            var root = json.DeserializeFromStream<RootObject>(stream);
            UtilsHelper.DebugInformation(logger, string.Format("[NextPVR] LastUpdate Response: {0}", json.SerializeToString(root)));
            return DateTimeOffset.FromUnixTimeSeconds(root.last_update);
        }
    }

    // Classes created with http://json2csharp.com/

    public class RootObject
    {
        public int last_update { get; set; }
        public string stat { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
    }
}
