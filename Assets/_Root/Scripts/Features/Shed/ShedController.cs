using Tool;
using Profile;
using System;
using System.Collections.Generic;
using UnityEngine;
using Features.Inventory;
using Features.Shed.Upgrade;
using JetBrains.Annotations;

namespace Features.Shed
{
    internal interface IShedController
    {
    }

    internal class ShedController : BaseController, IShedController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Shed/ShedView");
        private readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Shed/UpgradeItemConfigDataSource");

        private readonly ShedView _view;
        private readonly ProfilePlayer _profilePlayer;
<<<<<<< Updated upstream
        private readonly InventoryController _inventoryController;
=======
        private readonly InventoryContext _inventoryContext;
>>>>>>> Stashed changes
        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;


        public ShedController(
            [NotNull] Transform placeForUi,
            [NotNull] ProfilePlayer profilePlayer)
        {
            if (placeForUi == null)
                throw new ArgumentNullException(nameof(placeForUi));

            _profilePlayer
                = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));

<<<<<<< Updated upstream
            _upgradeHandlersRepository = CreateRepository();
            _inventoryController = CreateInventoryController(placeForUi);
=======
            _inventoryContext = CreateInventoryContext(placeForUi, _profilePlayer.Inventory);
            _upgradeHandlersRepository = CreateRepository();
>>>>>>> Stashed changes
            _view = LoadView(placeForUi);

            _view.Init(Apply, Back);
        }


<<<<<<< Updated upstream
=======
        private InventoryContext CreateInventoryContext(Transform placeForUi, IInventoryModel model)
        {
            var context = new InventoryContext(placeForUi, model);
            AddContext(context);

            return context;
        }

>>>>>>> Stashed changes
        private UpgradeHandlersRepository CreateRepository()
        {
            UpgradeItemConfig[] upgradeConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);
            var repository = new UpgradeHandlersRepository(upgradeConfigs);
            AddRepository(repository);

            return repository;
        }

<<<<<<< Updated upstream
        private InventoryController CreateInventoryController(Transform placeForUi)
        {
            var inventoryController = new InventoryController(placeForUi, _profilePlayer.Inventory);
            AddController(inventoryController);

            return inventoryController;
        }

        private ShedView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUi, false);
=======
        private ShedView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
>>>>>>> Stashed changes
            AddGameObject(objectView);

            return objectView.GetComponent<ShedView>();
        }


        private void Apply()
        {
            _profilePlayer.CurrentCar.Restore();

            UpgradeWithEquippedItems(
                _profilePlayer.CurrentCar,
                _profilePlayer.Inventory.EquippedItems,
                _upgradeHandlersRepository.Items);

            _profilePlayer.CurrentState.Value = GameState.Start;
<<<<<<< Updated upstream
            Log($"Apply. Current Speed: {_profilePlayer.CurrentCar.Speed}"
                + $"Current Jump force: {_profilePlayer.CurrentCar.JumpForce}");
=======

            Log("Apply. " +
                $"Current Speed: {_profilePlayer.CurrentCar.Speed}. " +
                $"Current Jump Height: {_profilePlayer.CurrentCar.JumpForce}");
>>>>>>> Stashed changes
        }

        private void Back()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
<<<<<<< Updated upstream
            Log($"Back. Current Speed: {_profilePlayer.CurrentCar.Speed}"
                + $"Current Jump force: {_profilePlayer.CurrentCar.JumpForce}");
=======

            Log("Back. " +
                $"Current Speed: {_profilePlayer.CurrentCar.Speed}. " +
                $"Current Jump Height: {_profilePlayer.CurrentCar.JumpForce}");
>>>>>>> Stashed changes
        }


        private void UpgradeWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<string> equippedItems,
            IReadOnlyDictionary<string, IUpgradeHandler> upgradeHandlers)
        {
            foreach (string itemId in equippedItems)
                if (upgradeHandlers.TryGetValue(itemId, out IUpgradeHandler handler))
                    handler.Upgrade(upgradable);
        }

        private void Log(string message) =>
            Debug.Log($"[{GetType().Name}] {message}");
    }
}
