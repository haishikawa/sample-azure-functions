﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Models.Settings.IConfig
{
    public interface IBlobStorageConfig
    {
        public string ContainerName { get; set; }
        public string ConnectionString { get; set; }
    }
}
