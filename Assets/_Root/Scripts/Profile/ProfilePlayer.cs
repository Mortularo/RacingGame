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


        public ProfilePlayer(float speedCar, float jumpForceCar, GameState initialState) : this(speedCar, jumpForceCar)
        {
            CurrentState.Value = initialState;
        }

        public ProfilePlayer(float speedCar, float jumpForceCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar, jumpForceCar);
            Inventory = new InventoryModel();
        }
    }
}
