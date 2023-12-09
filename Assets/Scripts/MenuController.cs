using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Action ActivateSettingsMenu;
    public Action ActivateShopMenu;
    public Action ActivateBonusMenu;
    public Action ActivateLevelsMenu;

    [SerializeField] private Canvas _menu;

    [SerializeField] private TextMeshProUGUI _cashText;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _levels;
    [SerializeField] private Button _bonus;

    private int _cash;

    private void Awake()
    {
        _settings.onClick.AddListener(OnSettingsButtonClick);
        _shop.onClick.AddListener(OnShopButtonClick);
        _levels.onClick.AddListener(OnLevelsButtonClick);
        _bonus.onClick.AddListener(OnBonusButtonClick);
    }

    public void Start()
    {
        _cash = PlayerPrefs.GetInt(GameConstants.ACTUAL_CASH);
        UpdateCash();
    }

    private void UpdateCash()
    {
        int cash = PlayerPrefs.GetInt(GameConstants.ACTUAL_CASH);

        if (cash == 0) // лучше сделать -1. Типа если это самый первый запуск игры.
                       // Иначе при расстрате всех денег можно снова косарь получить при запуске игры
        {
            _cash = 1000;
            PlayerPrefs.SetInt(GameConstants.ACTUAL_CASH, _cash);
            _cashText.text = _cash.ToString();

        }
        else
        {
            _cashText.text = cash.ToString();
        }
    }

    public void ChangeCash(int value)
    {
        _cash += value;
        _cashText.text = _cash.ToString();
        PlayerPrefs.SetInt(GameConstants.ACTUAL_CASH, _cash);
    }

    public void ActivateMainMenu(bool needActivate) => _menu.gameObject.SetActive(needActivate);

    #region OnButtonsClick

    private void OnSettingsButtonClick()
    {
        ActivateSettingsMenu?.Invoke();
    }

    private void OnShopButtonClick()
    {
        ActivateShopMenu?.Invoke();
    }

    private void OnLevelsButtonClick()
    {
        ActivateLevelsMenu?.Invoke();
    }

    private void OnBonusButtonClick()
    {
        ActivateBonusMenu?.Invoke();
    }

    #endregion

    private void OnDestroy()
    {
        _settings.onClick.RemoveListener(OnSettingsButtonClick);
        _shop.onClick.RemoveListener(OnShopButtonClick);
        _levels.onClick.RemoveListener(OnLevelsButtonClick);
        _bonus.onClick.RemoveListener(OnBonusButtonClick);
    }
}