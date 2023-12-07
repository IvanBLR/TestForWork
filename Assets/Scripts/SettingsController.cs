using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Canvas _settings;

    public void ActivateSettingsMenu(bool needActivate) => _settings.gameObject.SetActive(needActivate);
}