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


        public ProfilePlayer(float speedCar, float jumpForce, GameState initialState)
            : this(speedCar, jumpForce)
        {
            CurrentState.Value = initialState;
        }

        public ProfilePlayer(float speedCar, float jumpForce)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar, jumpForce);
            Inventory = new InventoryModel();
        }
    }
}
