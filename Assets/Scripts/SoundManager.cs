using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class SoundManager : MonoBehaviour
{
    //TODO: некорректно работают конпки выключения звука и воспроизведения: смешиваются аудио-дорожки
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _purchases;
    [SerializeField] private AudioClip _bonus;

    [SerializeField] private AudioClip _soundTrack1;
    [SerializeField] private AudioClip _soundTrack2;
    [SerializeField] private AudioClip _soundTrack3;
    [SerializeField] private AudioClip _soundTrack4;

    private bool _isSoundOn = true;

    private float _volumeValue;

    //  private int _soundTrackNumber = 1;
    public void ChangeVolume(float value)
    {
        _volumeValue = value;
        if (_isSoundOn)
            _audioSource.volume = _volumeValue;
    }

    public void SoundOff(bool isSoundOff)
    {
        _isSoundOn = isSoundOff;

        if (_isSoundOn)
        {
            _audioSource.volume = _volumeValue;
            _audioSource.Play();
        }
        else
            _audioSource.Pause();
    }

    public void ChangeTrack(int trackNumber)
    {
        _audioSource.Stop();
        //_soundTrackNumber = trackNumber;

        if (_isSoundOn)
        {
            switch (trackNumber)
            {
                case 1:
                    _audioSource.PlayOneShot(_soundTrack1);
                    break;
                case 2:
                    _audioSource.PlayOneShot(_soundTrack2);
                    break;
                case 3:
                    _audioSource.PlayOneShot(_soundTrack3);
                    break;
                case 4:
                    _audioSource.PlayOneShot(_soundTrack4);
                    break;
            }
        }
    }
}