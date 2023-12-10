using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _purchases;
    [SerializeField] private AudioClip _bonus;

    [SerializeField] private AudioClip[] _audioTracks;

    private bool _isSoundOn = true;
    private float _volumeValue;

    private void Start()
    {
        _audioSource.volume = PlayerPrefs.GetFloat(GameConstants.VOLUME_VALUE);
        int sound = PlayerPrefs.GetInt(GameConstants.SOUND_ON);
        if (sound != 0)
            _audioSource.Pause();
    }

    [UsedImplicitly] // добавлен на все кнопки. Это звук клика на кнопку
    public void PlaySoundOnButtonClick()
    {
        if (_isSoundOn)
            _audioSource.PlayOneShot(_click);
    }

    public void ChangeVolume(float value)
    {
        _audioSource.volume = value;
    }

    public void SoundOff(bool isSoundOn)
    {
        _isSoundOn = isSoundOn;

        if (isSoundOn)
            _audioSource.Play();
        else
            _audioSource.Pause();
    }

    public void ChangeTrack(int trackIndex)
    {
        if (trackIndex < _audioTracks.Length)
        {
            _audioSource.Stop();
            _audioSource.clip = _audioTracks[trackIndex];
            if (_isSoundOn)
            {
                _audioSource.Play();
            }
        }
    }
}