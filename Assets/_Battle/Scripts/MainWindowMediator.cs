using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScripts
{
    internal class MainWindowMediator : MonoBehaviour
    {
        [Header("Player Stats")]
        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TMP_Text _countPowerText;
        [SerializeField] private TMP_Text _countCrimeRateText;

        [Header("Enemy Stats")]
        [SerializeField] private TMP_Text _countPowerEnemyText;

        [Header("Money Buttons")]
        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private Button _minusMoneyButton;

        [Header("Health Buttons")]
        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;

        [Header("Power Buttons")]
        [SerializeField] private Button _addPowerButton;
        [SerializeField] private Button _minusPowerButton;

        [Header("Crime Rating Buttons")]
        [SerializeField] private Button _addCrimeRateButton;
        [SerializeField] private Button _minusCrimeRateButton;

        [Header("Other Buttons")]
        [SerializeField] private Button _escapeButton;
        [SerializeField] private Button _fightButton;

        private PlayerData _money;
        private PlayerData _heath;
        private PlayerData _power;
        private PlayerData _crimeRate;

        private Enemy _enemy;


        private void Start()
        {
            _enemy = new Enemy("Enemy Flappy");

            _money = CreatePlayerData(DataType.Money);
            _heath = CreatePlayerData(DataType.Health);
            _power = CreatePlayerData(DataType.Power);
            _crimeRate = CreatePlayerData(DataType.CrimeRate);

            Subscribe();
        }

        private void OnDestroy()
        {
            DisposePlayerData(ref _money);
            DisposePlayerData(ref _heath);
            DisposePlayerData(ref _power);
            DisposePlayerData(ref _crimeRate);

            Unsubscribe();
        }


        private PlayerData CreatePlayerData(DataType dataType)
        {
            PlayerData playerData = new PlayerData(dataType);
            playerData.Attach(_enemy);

            return playerData;
        }

        private void DisposePlayerData(ref PlayerData playerData)
        {
            playerData.Detach(_enemy);
            playerData = null;
        }


        private void Subscribe()
        {
            _addMoneyButton.onClick.AddListener(IncreaseMoney);
            _minusMoneyButton.onClick.AddListener(DecreaseMoney);

            _addHealthButton.onClick.AddListener(IncreaseHealth);
            _minusHealthButton.onClick.AddListener(DecreaseHealth);

            _addPowerButton.onClick.AddListener(IncreasePower);
            _minusPowerButton.onClick.AddListener(DecreasePower);

            _addCrimeRateButton.onClick.AddListener(IncreaseCrimeRate);
            _minusCrimeRateButton.onClick.AddListener(DecreaseCrimeRate);

            _fightButton.onClick.AddListener(Fight);
            _escapeButton.onClick.AddListener(Escape);
        }

        private void Unsubscribe()
        {
            _addMoneyButton.onClick.RemoveAllListeners();
            _minusMoneyButton.onClick.RemoveAllListeners();

            _addHealthButton.onClick.RemoveAllListeners();
            _minusHealthButton.onClick.RemoveAllListeners();

            _addPowerButton.onClick.RemoveAllListeners();
            _minusPowerButton.onClick.RemoveAllListeners();

            _addCrimeRateButton.onClick.RemoveAllListeners();
            _minusCrimeRateButton.onClick.RemoveAllListeners();

            _fightButton.onClick.RemoveAllListeners();
            _escapeButton.onClick.RemoveAllListeners();
        }


        private void IncreaseMoney() => IncreaseValue(_money);
        private void DecreaseMoney() => DecreaseValue(_money);

        private void IncreaseHealth() => IncreaseValue(_heath);
        private void DecreaseHealth() => DecreaseValue(_heath);

        private void IncreasePower() => IncreaseValue(_power);
        private void DecreasePower() => DecreaseValue(_power);

        private void IncreaseCrimeRate() => IncreaseValue(_crimeRate);
        private void DecreaseCrimeRate() => DecreaseValue(_crimeRate);

        private void IncreaseValue(PlayerData playerData) => AddToValue(1, playerData);
        private void DecreaseValue(PlayerData playerData) => AddToValue(-1, playerData);

        private void AddToValue(int addition, PlayerData playerData)
        {
            playerData.Value += addition;
            ChangeDataWindow(playerData);
            MakeEscapeButtonVisible();
        }

        private void ChangeDataWindow(PlayerData playerData)
        {
            int value = playerData.Value;
            DataType dataType = playerData.DataType;
            TMP_Text textComponent = GetTextComponent(dataType);
            textComponent.text = $"Player {dataType:F} {value}";

            int enemyPower = _enemy.CalcPower();
            _countPowerEnemyText.text = $"Enemy Power {enemyPower}";
        }

        private TMP_Text GetTextComponent(DataType dataType) =>
            dataType switch
            {
                DataType.Money => _countMoneyText,
                DataType.Health => _countHealthText,
                DataType.Power => _countPowerText,
                DataType.CrimeRate => _countCrimeRateText,
                _ => throw new ArgumentException($"Wrong {nameof(DataType)}")
            };


        private void Fight()
        {
            int enemyPower = _enemy.CalcPower();
            bool isVictory = _power.Value >= enemyPower;

            string color = isVictory ? "#07FF00" : "#FF0000";
            string message = isVictory ? "Win" : "Lose";

            Debug.Log($"<color={color}>{message}!!!</color>");
        }

        private void Escape()
        {
            Debug.Log("You have successfully escaped!");
        }

        private void MakeEscapeButtonVisible()
        {
            const int MinCrimeLevel = 0;
            const int MaxCrimeLevel = 5;
            const int MaxEscapeLevel = 2;

            int CrimeLevel = _crimeRate.Value;
            bool IsUsable = MinCrimeLevel <= CrimeLevel&&CrimeLevel <= MaxEscapeLevel;
            bool IsShown = MinCrimeLevel <= CrimeLevel && CrimeLevel <= MaxCrimeLevel;

            _escapeButton.interactable = IsUsable;
            _escapeButton.gameObject.SetActive(IsShown);
        }
    }
}
