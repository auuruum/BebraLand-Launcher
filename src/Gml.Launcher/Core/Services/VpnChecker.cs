using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace Gml.Launcher.Core.Services;

public class VpnChecker : IVpnChecker
{
    public bool IsUseVpnTunnel()
    {
        return false;
    }
}
