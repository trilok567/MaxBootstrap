﻿using MaxBootstrap.Core.Packages;
using System;
using MaxBootstrap.Core.Enums;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace MaxBootstrap.Core
{
    public interface IBootstrapperController
    {
        event Action<string> OnCriticalError;

        IntPtr WindowHandle { get; set;  }

        int FinalResult { get; }

        string Error { get; }

        bool Cancelled { get; }

        bool UpgradeDetected { get; }

        bool PreviouslyInstalled { get; }

        LaunchAction LaunchAction { get; }

        InstallationResult InstallationResult { get; }

        bool RestartRequired { get; }

        MaxBootstrapper WixBootstrapper { get; }

        IPageController PageController { get; }

        IPackageManager PackageManager { get; }
    }
}
