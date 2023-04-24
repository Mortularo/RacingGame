using Tool;
using Profile;
using System;
using System.Collections.Generic;
using UnityEngine;
using Features.Inventory;
using Features.Shed.Upgrade;
using JetBrains.Annotations;
using Object = UnityEngine.Object;

namespace Features.Shed
{
    internal interface IShedController
    {
    }

    internal class ShedController : BaseController, IShedController
    {
        private readonly IShedView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly InventoryContext _inventoryContext;
        private readonly IUpgradeHandlersRepository _upgradeHandlersRepository;


        public ShedController(
            //[NotNull] Transform placeForUi,
            //[NotNull] ProfilePlayer profilePlayer,
            [NotNull] InventoryContext inventoryContext,
            [NotNull] IUpgradeHandlersRepository createRepository,
            [NotNull] IShedView loadView)
        {
            //if (placeForUi == null)
            //    throw new ArgumentNullException(nameof(placeForUi));

            //_profilePlayer
            //    = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));

            _inventoryContext
                = inventoryContext ?? throw new ArgumentNullException(nameof(inventoryContext));

            _upgradeHandlersRepository
                = createRepository ?? throw new ArgumentNullException(nameof(createRepository));

            _view
                = loadView ?? throw new ArgumentNullException(nameof(loadView));

            //    = CreateInventoryContext(placeForUi, _profilePlayer.Inventory);
            //_upgradeHandlersRepository = CreateRepository();
            //_view = LoadView(placeForUi);

            _view.Init(Apply, Back);
        }

        private void Apply()
        {
            _profilePlayer.CurrentCar.Restore();

            UpgradeWithEquippedItems(
                _profilePlayer.CurrentCar,
                _profilePlayer.Inventory.EquippedItems,
                _upgradeHandlersRepository.Items);

            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Apply. Current Speed: {_profilePlayer.CurrentCar.Speed}");
        }

        private void Back()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Back. Current Speed: {_profilePlayer.CurrentCar.Speed}");
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
    }
}
