﻿//
// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
//
using System;
using System.Collections.Generic;
using System.Text;

namespace NPanday.ProjectImporter.ImporterTests
{
    public abstract class AbstractAzureImportTest : AbstractProjectImportTest
    {
        public override List<Artifact.Artifact> GetTestArtifacts()
        {
            // values for Azure SDK 1.6, which is the default
            List<Artifact.Artifact> artifacts = new List<Artifact.Artifact>();
            artifacts.Add(createArtifact("Microsoft.WindowsAzure.Diagnostics", "1.0.0.0"));
            artifacts.Add(createArtifact("Microsoft.WindowsAzure.ServiceRuntime", "1.0.0.0"));
            artifacts.Add(createArtifact("Microsoft.WindowsAzure.StorageClient", "1.1.0.0"));
            return artifacts;
        }
    }
}
