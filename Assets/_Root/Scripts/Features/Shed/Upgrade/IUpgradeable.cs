namespace Features.Shed.Upgrade
{
    internal interface IUpgradable
    {
        float Speed { get; set; }
        float JumpForce { get; set; }

        void Restore();
    }
}
