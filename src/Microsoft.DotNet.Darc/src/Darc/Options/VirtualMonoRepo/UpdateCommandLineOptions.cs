// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommandLine;
using Microsoft.DotNet.Darc.Operations;
using Microsoft.DotNet.Darc.Operations.VirtualMonoRepo;
using Microsoft.DotNet.DarcLib;

namespace Microsoft.DotNet.Darc.Options.VirtualMonoRepo;

[Verb("update", HelpText = "Updates given repo(s) in the VMR to match given refs.")]
internal class UpdateCommandLineOptions : VmrSyncCommandLineOptions
{
    [Option("no-squash", HelpText = "Synchronizes commit by commit instead of squashing all updates into one.")]
    public bool NoSquash { get; set; } = false;
    
    [Option('r', "recursive", Required = false, HelpText = $"Process also dependencies (from {VersionFiles.VersionDetailsXml}) recursively.")]
    public bool Recursive { get; set; } = false;

    public override Operation GetOperation() => new UpdateOperation(this);
}
