using System;
using JetBrains.Annotations;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public Action<float> VolumeChange;
    public Action<int> SoundTrackChange;
    public Action<bool> SoundOnOff;

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