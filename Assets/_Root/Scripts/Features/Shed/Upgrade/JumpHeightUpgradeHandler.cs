namespace Features.Shed.Upgrade
{
    internal class JumpHeightUpgradeHandler : IUpgradeHandler
    {
        private readonly float _jumpHeight;

        public JumpHeightUpgradeHandler(float jumpHeight) =>
            _jumpHeight = jumpHeight;

        public void Upgrade(IUpgradable upgradable) =>
            upgradable.JumpForce += _jumpHeight;
    }
}
