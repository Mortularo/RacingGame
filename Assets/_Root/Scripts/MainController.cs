using Ui;
using Game;
using Profile;
using UnityEngine;
using Features.Shed;
using System;
using Features.Inventory;
using Features.Shed.Upgrade;
using Tool;
using Object = UnityEngine.Object;
using System.Collections.Generic;

internal class MainController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Shed/ShedView");
    private readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Shed/UpgradeItemConfigDataSource");

    private readonly List<GameObject> _subObjects = new List<GameObject>();
    private readonly List<IDisposable> _subDisposables = new List<IDisposable>();

    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private SettingsMenuController _settingsMenuController;
    private ShedController _shedController;
    private GameController _gameController;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        DisposeControllers();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        DisposeControllers();

        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Shed:
                _shedController = CreateShedController(_profilePlayer, _placeForUi);
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                break;
        }
    }

    private void DisposeControllers()
    {
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
        _gameController?.Dispose();
    }
    private void DisposeSubs()
    {
        DisposeSubObjects();
        DisposeSubDisposables();
    }

    private void DisposeSubObjects()
    {
        foreach (GameObject gObject in _subObjects)
            Object.Destroy(gObject);
    }
    private void DisposeSubDisposables()
    {
        foreach (IDisposable disposable in _subDisposables)
            disposable.Dispose();
    }

    private ShedController CreateShedController(ProfilePlayer profilePlayer, Transform placeForUi)
    {
        InventoryContext inventoryContext = CreateInventoryContext(placeForUi, profilePlayer.Inventory);
        UpgradeHandlersRepository createRepository = CreateRepository();
        ShedView view = LoadView(placeForUi);

        return new ShedController(inventoryContext, createRepository, view);
    }
    private InventoryContext CreateInventoryContext(Transform placeForUi, IInventoryModel model)
    {
        var context = new InventoryContext(placeForUi, model);
        _subDisposables.Add(context);

        return context;
    }

    private UpgradeHandlersRepository CreateRepository()
    {
        UpgradeItemConfig[] upgradeConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);
        var repository = new UpgradeHandlersRepository(upgradeConfigs);
        _subDisposables.Add(repository);

        return repository;
    }

    private ShedView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        _subObjects.Add(objectView);

        return objectView.GetComponent<ShedView>();
    }
}
