using UnityEngine;

namespace Rewards
{
    internal class InstallView : MonoBehaviour
    {
        [SerializeField] private RewardView _dailyRewardView;

        private RewardController _dailyRewardController;


        private void Awake() =>
            _dailyRewardController = new RewardController(_dailyRewardView);

        private void Start() =>
            _dailyRewardController.Init();

        private void OnDestroy() =>
            _dailyRewardController.Deinit();
    }
}
