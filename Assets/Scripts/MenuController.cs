using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Action ActivateSettingsMenu;
    public Action ActivateShopMenu;
    public Action ActivateBonusMenu;
    public Action ActivateLevelsMenu;
    //public Action DailyBonusActivate;

    [SerializeField] private Canvas _menu;

    [SerializeField] private TextMeshProUGUI _cash;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _levels;
    [SerializeField] private Button _bonus;

    private void Awake()
    {
        _settings.onClick.AddListener(OnSettingsButtonClick);
        _shop.onClick.AddListener(OnShopButtonClick);
        _levels.onClick.AddListener(OnLevelsButtonClick);
        _bonus.onClick.AddListener(OnBonusButtonClick);
    }

    public void ChangeCash(int value)
    {
        int cash = Convert.ToInt32(_cash.text);
        _cash.text = (cash + value).ToString();
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