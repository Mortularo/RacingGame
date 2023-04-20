using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    [SerializeField] private float SpeedCar;
    [SerializeField] private float JumpForceCar;
    [SerializeField] private GameState InitialState = GameState.Start;

    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;


    private void Start()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, JumpForceCar, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
