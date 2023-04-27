using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private float SpeedCar;
    [SerializeField] private float JumpForceCar;
    [SerializeField] private GameState InitialState = GameState.Start;
=======
    [Header("Initial Settings")]
    [SerializeField] private float _speedCar;
    [SerializeField] private float _jumpHeightCar;
    [SerializeField] private GameState _initialState;
>>>>>>> Stashed changes

    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;


    private void Start()
    {
<<<<<<< Updated upstream
        var profilePlayer = new ProfilePlayer(SpeedCar, JumpForceCar, InitialState);
=======
        var profilePlayer = new ProfilePlayer(_speedCar, _jumpHeightCar, _initialState);
>>>>>>> Stashed changes
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
