﻿using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using System;

namespace FluentMigrator.ServiceStack.ServiceModel
{
    [Route("/migrations", "GET")]
    public class VersionInfo : IReturn<VersionInfoResponse>
    {
        public long? Version { get; set; }

        public DateTime? AppliedOn { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public override bool Equals(object obj)
        {
            return Version == ((VersionInfo)obj).Version;
        }

        public override int GetHashCode()
        {
            return (Version ?? 0).GetHashCode();
        }
    }
}