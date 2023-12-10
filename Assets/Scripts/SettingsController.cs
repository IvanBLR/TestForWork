using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SettingsController : MonoBehaviour
{
    public Action<float> VolumeChange;
    public Action<int> SoundTrackChange;
    public Action<bool> SoundOff;

    [SerializeField] private Canvas _settings;
    [SerializeField] private Slider _volume;
    [SerializeField] private Button _soundTumbler;

    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private bool _isSoundOn = true;

    private void Start()
    {
        _volume.value = PlayerPrefs.GetFloat(GameConstants.VOLUME_VALUE);
    }

    [UsedImplicitly] // назначен на слайдер
    public void OnVolumeChange()
    {
        PlayerPrefs.SetFloat(GameConstants.VOLUME_VALUE, _volume.value);
        VolumeChange?.Invoke(_volume.value);
    }

    [UsedImplicitly] // назначен на кнопку Музыка.
    public void OnSoundTrackChange()
    {
        int trackNumber = Random.Range(0, 5);
        SoundTrackChange?.Invoke(trackNumber);
    }

    [UsedImplicitly] // назначен на button-тумблер
    public void OnSoundOff()
    {
        int sound = 0;
        _isSoundOn = !_isSoundOn;
        if (_isSoundOn)
            sound = 1;
        PlayerPrefs.SetInt(GameConstants.SOUND_ON, sound);
        if (_isSoundOn)
            _soundTumbler.image.sprite = _soundOn;
        else
            _soundTumbler.image.sprite = _soundOff;

        SoundOff?.Invoke(_isSoundOn);
    }

    public void ActivateSettingsMenu(bool needActivate) => _settings.gameObject.SetActive(needActivate);
}