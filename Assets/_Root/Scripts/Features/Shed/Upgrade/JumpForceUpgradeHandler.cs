using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Shed.Upgrade
{
    internal class JumpForceUpgradeHandler : IUpgradeHandler
    {
        private readonly float _jumpForce;

        public JumpForceUpgradeHandler(float jumpForce)
        {
            _jumpForce = jumpForce;
        }

        public void Upgrade(IUpgradable upgradable)
        {
            upgradable.JumpForce += _jumpForce;
        }
    }
}
