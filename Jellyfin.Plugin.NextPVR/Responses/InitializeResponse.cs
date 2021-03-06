﻿using System;
using System.IO;
using Microsoft.Extensions.Logging;
using MediaBrowser.Model.Serialization;
using Jellyfin.Plugin.NextPVR.Helpers;

namespace Jellyfin.Plugin.NextPVR.Responses
{
    public class InitializeResponse
    {
        public bool LoggedIn(Stream stream, IJsonSerializer json, ILogger<LiveTvService> logger)
        {
            var root = json.DeserializeFromStream<RootObject>(stream);

            if (root.stat != "")
            {
                UtilsHelper.DebugInformation(logger, string.Format("[NextPVR] Connection validation: {0}", json.SerializeToString(root)));
                return root.stat == "ok";
            }
            logger.LogError("[NextPVR] Failed to validate your connection with NextPVR.");
            throw new Exception("Failed to validate your connection with NextPVR.");
        }

        public class RootObject
        {
            public string stat { get; set; }
            public string sid { get; set; }
        }
    }
}
