using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ViewManager _viewManager;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AdsManager _adsManager;


    private void Start()
    {
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
}
