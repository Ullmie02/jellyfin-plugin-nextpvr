﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MediaBrowser.Model.Serialization;
using Jellyfin.Plugin.NextPVR.Helpers;

namespace Jellyfin.Plugin.NextPVR.Responses
{
    public class CancelDeleteRecordingResponse
    {
        public bool? RecordingError(Stream stream, IJsonSerializer json, ILogger<LiveTvService> logger)
        {
            var root = json.DeserializeFromStream<RootObject>(stream);

            if (root.stat != "ok")
            {
                UtilsHelper.DebugInformation(logger, string.Format("[NextPVR] RecordingError Response: {0}", json.SerializeToString(root)));
                return true;
            }
            return false;
        }

        public class RootObject
        {
            public string stat { get; set; }
        }
    }
}
