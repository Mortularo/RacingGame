using UnityEngine;
using Profile;
using Tool;

namespace Features.ReturnToMenu
{
    internal class ReturnToMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Return/ReturnToMenuView");

        private readonly ReturnToMenuView _view;
        private readonly ProfilePlayer _profilePlayer;

        public ReturnToMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(OpenMenu);
        }

        private ReturnToMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<ReturnToMenuView>();
        }

        private void OpenMenu() => _profilePlayer.CurrentState.Value = GameState.Start;
    }
}
