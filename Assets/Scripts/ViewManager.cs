using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private MenuController _menu;
    [SerializeField] private BonusController _dailyBonus;
    [SerializeField] private SettingsController _settings;
    [SerializeField] private ShopController _shop;
    [SerializeField] private LevelsController _levels;


    private void Awake()
    {
        ReturnToMainMenu();
    }

    [UsedImplicitly]// назначен на все кнопки "Меню"
    public void ReturnToMainMenu()
    {
        _menu.ActivateMainMenu(true);
        _dailyBonus.ActivateBonusMenu(false);
        _settings.ActivateSettingsMenu(false);
        _shop.ActivateShopMenu(false);
        _levels.ActivateLevelsMenu(false);
    }
}
