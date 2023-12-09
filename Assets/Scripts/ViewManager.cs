using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public Action<float> VolumeChange;
    public Action<int> SoundTrackChange;
    public Action<bool> SoundOnOff;
    //public Action DailyBonusActivate;

    [SerializeField] private MenuController _menu;
    [SerializeField] private BonusController _dailyBonus;
    [SerializeField] private SettingsController _settings;
    [SerializeField] private ShopController _shop;
    [SerializeField] private LevelsController _levels;

    private void Awake()
    {
        ReturnToMainMenu();
    }

    private void Start()
    {
        _menu.ActivateBonusMenu += ActivateBonusMenu;
        _menu.ActivateSettingsMenu += ActivateSettingsMenu;
        _menu.ActivateLevelsMenu += ActivateLevelsMenu;
        _menu.ActivateShopMenu += ActivateShopMenu;

        _settings.SoundTrackChange += OnSoundTrackChange;
        _settings.VolumeChange += OnVolumeValueChanged;
        _settings.SoundOff += OnSoundOff;

        _dailyBonus.DailyBonusGot += _menu.ChangeCash;
    }

    private void OnDestroy()
    {
        _menu.ActivateBonusMenu -= ActivateBonusMenu;
        _menu.ActivateSettingsMenu -= ActivateSettingsMenu;
        _menu.ActivateLevelsMenu -= ActivateLevelsMenu;
        _menu.ActivateShopMenu -= ActivateShopMenu;

        _settings.VolumeChange -= OnVolumeValueChanged;
        _settings.SoundTrackChange -= OnSoundTrackChange;
        _settings.SoundOff -= OnSoundOff;
        
        _dailyBonus.DailyBonusGot -= _menu.ChangeCash;

    }

    [UsedImplicitly] // назначен на все кнопки "Меню"
    public void ReturnToMainMenu()
    {
        _menu.ActivateMainMenu(true);
        _dailyBonus.ActivateBonusMenu(false);
        _settings.ActivateSettingsMenu(false);
        _shop.ActivateShopMenu(false);
        _levels.ActivateLevelsMenu(false);
    }

    // public void SetActualCashView(string cash)
    // {
    //     _menu.UpdateCashView(cash);
    // }
    public void DailyBonusActivate()
    {
        _dailyBonus.ActivateBonusButton();
    }
    
    private void OnSoundTrackChange(int trackNumber)
    {
        SoundTrackChange?.Invoke(trackNumber);
    }

    private void OnVolumeValueChanged(float value)
    {
        VolumeChange?.Invoke(value);
    }

    private void OnSoundOff(bool isSoundOff)
    {
        SoundOnOff?.Invoke(isSoundOff);
    }

    #region MenuActivations

    private void ActivateBonusMenu()
    {
       //PlayerPrefs.SetString(GameConstants.LAST_BONUS_DATA, System.DateTime.Today);
        _dailyBonus.ActivateBonusMenu(true);
        _menu.ActivateMainMenu(false);
    }

    private void ActivateSettingsMenu()
    {
        _settings.ActivateSettingsMenu(true);
        _menu.ActivateMainMenu(false);
    }

    private void ActivateShopMenu()
    {
        _shop.ActivateShopMenu(true);
        _menu.ActivateMainMenu(false);
    }

    private void ActivateLevelsMenu()
    {
        _levels.ActivateLevelsMenu(true);
        _menu.ActivateMainMenu(false);
    }

    #endregion
}