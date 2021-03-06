﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

using System.Collections.Generic;

namespace Microsoft.Diagnostics.EventFlow.Configuration
{
    // !!ACTION!!
    // If you make any changes here, please update the README.md file to reflect the new configuration
    public class HttpOutputConfiguration: ItemConfiguration
    {
        public static readonly HttpOutputFormat DefaultFormat = HttpOutputFormat.Json;

        public string ServiceUri { get; set; }
        public HttpOutputFormat Format { get; set; }
        public string HttpContentType { get; set; }
        public string BasicAuthenticationUserName { get; set; }
        public string BasicAuthenticationUserPassword { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public HttpOutputConfiguration()
        {
            Format = DefaultFormat;
            HttpContentType = "application/json";
            Headers = new Dictionary<string, string>();
        }

        public HttpOutputConfiguration DeepClone()
        {
            var other = new HttpOutputConfiguration()
            {
                ServiceUri = this.ServiceUri,
                Format = this.Format,
                HttpContentType = this.HttpContentType,
                BasicAuthenticationUserName = this.BasicAuthenticationUserName,
                BasicAuthenticationUserPassword = this.BasicAuthenticationUserPassword,
                Headers = new Dictionary<string, string>(this.Headers)
            };

            return other;
        }
    }
}
