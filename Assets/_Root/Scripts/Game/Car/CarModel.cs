using Features.Shed.Upgrade;

namespace Game.Car
{
    internal class CarModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpHeight;

        public float Speed { get; set; }
        public float JumpForce { get; set; }


<<<<<<< Updated upstream
        public CarModel(float speed, float jumpForce)
        {
            _defaultSpeed = speed;
            Speed = speed;
            _defaultJumpForce = jumpForce;
            JumpForce = jumpForce;
=======
        public CarModel(float speed, float jumpHeight)
        {
            _defaultSpeed = speed;
            _defaultJumpHeight = jumpHeight;

            Speed = speed;
            JumpForce = jumpHeight;
>>>>>>> Stashed changes
        }


        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpForce = _defaultJumpHeight;
        }
    }
}
