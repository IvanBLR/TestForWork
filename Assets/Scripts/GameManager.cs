using System;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ViewManager _viewManager;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AdsManager _adsManager;


    private void Start()
    {
        UpdateDailyBonusDate();

        _viewManager.VolumeChange += _soundManager.ChangeVolume;
        _viewManager.SoundTrackChange += _soundManager.ChangeTrack;
        _viewManager.SoundOnOff += _soundManager.SoundOff;
    }

    private void OnDestroy()
    {
        _viewManager.VolumeChange -= _soundManager.ChangeVolume;
        _viewManager.SoundTrackChange -= _soundManager.ChangeTrack;
        _viewManager.SoundOnOff -= _soundManager.SoundOff;
    }

    private void UpdateDailyBonusDate()
    {
        DateTime currentData = DateTime.Now;
        string lastData = PlayerPrefs.GetString(GameConstants.LAST_BONUS_DATE);

        try
        {
            DateTime lastDateTime = DateTime.Parse(lastData);
            TimeSpan diffrence = currentData.Subtract(lastDateTime);

            if (diffrence.Seconds >= 10) // TODO: изменить на часы
            {
                _viewManager.DailyBonusActivate();
                PlayerPrefs.SetString(GameConstants.LAST_BONUS_DATE, currentData.ToString("o"));
            }
        }
        catch (FormatException exception)
        {
            PlayerPrefs.SetString(GameConstants.LAST_BONUS_DATE, currentData.ToString("o"));
            Console.WriteLine(exception);
        }
    }
}