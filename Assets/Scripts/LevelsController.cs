using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private Canvas _levels;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Sprite _unlockedSprite;
    [SerializeField] private Button[] _levelButtons;

    private int _currentUnlockedLevel;

    private void Start()
    {
        _currentUnlockedLevel = PlayerPrefs.GetInt(GameConstants.LAST_UNLOCKED_LEVEL);
        if (_currentUnlockedLevel == 0)
        {
            _currentUnlockedLevel = 3;
            PlayerPrefs.SetInt(GameConstants.LAST_UNLOCKED_LEVEL, _currentUnlockedLevel);
        }

        UpdateUnlockedLevels();
    }

    [UsedImplicitly] // назначен на вертикальный скролл, чтобы не листали сильно много вниз
    public void OnScrolling()
    {
        if (_scrollbar.value < 0)
            _scrollbar.value = 0;
    }

    public void ActivateLevelsMenu(bool needActivate) => _levels.gameObject.SetActive(needActivate);

    private void UpdateUnlockedLevels()
    {
        int lastIndex = _currentUnlockedLevel - 1;
        for (int i = 0; i < lastIndex; i++)
        {
            _levelButtons[i].image.sprite = _unlockedSprite;
            _levelButtons[i].interactable = true;
        }
    }
}