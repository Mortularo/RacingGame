using Tool;
using Game.Car;
using Features.Inventory;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;
        public readonly InventoryModel Inventory;


<<<<<<< Updated upstream
        public ProfilePlayer(float speedCar, float jumpForce, GameState initialState)
            : this(speedCar, jumpForce)
=======
        public ProfilePlayer(float speedCar, float jumpHeightCar, GameState initialState) : this(speedCar, jumpHeightCar)
>>>>>>> Stashed changes
        {
            CurrentState.Value = initialState;
        }

<<<<<<< Updated upstream
        public ProfilePlayer(float speedCar, float jumpForce)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar, jumpForce);
=======
        public ProfilePlayer(float speedCar, float jumpHeightCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar, jumpHeightCar);
>>>>>>> Stashed changes
            Inventory = new InventoryModel();
        }
    }
}
