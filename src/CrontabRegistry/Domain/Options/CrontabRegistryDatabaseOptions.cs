using System;
using System.Collections.Generic;
using System.Text;

namespace CrontabRegistry.Domain.Options
{
    public class CrontabRegistryDatabaseOptions
    {
        public string ConnectionString { set; get; } = string.Empty;
        public string DatabaseName { set; get; } = string.Empty;
        public string SummariesCollectionName { set; get; } = string.Empty;
    }
}
