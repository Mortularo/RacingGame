using Features.Shed.Upgrade;

namespace Game.Car
{
    internal class CarModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpForce;

        public float Speed { get; set; }
        public float JumpForce { get; set; }


        public CarModel(float speed, float jumpForce)
        {
            _defaultSpeed = speed;
            Speed = speed;
            _defaultJumpForce = jumpForce;
            JumpForce = jumpForce;
        }


        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpForce = _defaultJumpForce;
        }
    }
}
