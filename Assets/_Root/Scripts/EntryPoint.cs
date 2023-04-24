using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    [Header("Initial Settings")]
    [SerializeField] private ProfileSettingsManager _manager;

    [Header("Scene Objects")]
    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;


    private void Start()
    {
        var profilePlayer = CreateProfilePlayer(_manager);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }

    private ProfilePlayer CreateProfilePlayer(ProfileSettingsManager manager) =>
    new ProfilePlayer(manager.CarSpeed, manager.CarJumpForce, manager.gameState);    
}
