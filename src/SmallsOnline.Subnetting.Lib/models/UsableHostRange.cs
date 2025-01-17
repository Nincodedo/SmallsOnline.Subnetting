using System;
using System.Net;

namespace SmallsOnline.Subnetting.Lib.Models
{
    public class UsableHostRange
    {
        public UsableHostRange(IPAddress netAddress, IPAddress broadcastAddress)
        {
            Initialize(netAddress, broadcastAddress);
        }

        public IPAddress FirstUsableHostAddress
        {
            get => _firstUsableHostAddress;
        }

        public IPAddress LastUsableHostAddress
        {
            get => _lastUsableHostAddress;
        }

        private IPAddress _firstUsableHostAddress;
        private IPAddress _lastUsableHostAddress;

        private void Initialize(IPAddress netAddress, IPAddress broadcastAddress)
        {
            byte[] netAddressBytes = netAddress.GetAddressBytes();
            byte[] broadcastAddressBytes = broadcastAddress.GetAddressBytes();

            _firstUsableHostAddress = new(new byte[] { netAddressBytes[0], netAddressBytes[1], netAddressBytes[2], (byte)(netAddressBytes[3] + 1) });
            _lastUsableHostAddress = new(new byte[] { broadcastAddressBytes[0], broadcastAddressBytes[1], broadcastAddressBytes[2], (byte)(broadcastAddressBytes[3] - 1) });
        }

        public override string ToString()
        {
            return $"{_firstUsableHostAddress} - {_lastUsableHostAddress}";
        }
    }
}