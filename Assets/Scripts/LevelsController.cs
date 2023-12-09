using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        //PlayerPrefs.SetInt(GameConstants.LAST_UNLOCKED_LEVEL, 1);  это строчка для сброса игры на 1 уровень. Для тестов
        _currentUnlockedLevel = PlayerPrefs.GetInt(GameConstants.LAST_UNLOCKED_LEVEL);
        if (_currentUnlockedLevel == 0)
        {
            _currentUnlockedLevel = 3;
            PlayerPrefs.SetInt(GameConstants.LAST_UNLOCKED_LEVEL, _currentUnlockedLevel);
        }

        UpdateUnlockedLevels();
    }

    [UsedImplicitly] // назначен на все кнопки уровней для запуска игры
    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ActivateLevelsMenu(bool needActivate) => _levels.gameObject.SetActive(needActivate);

    private void UpdateUnlockedLevels()
    {
        for (int i = 0; i < _currentUnlockedLevel; i++)
        {
            _levelButtons[i].image.sprite = _unlockedSprite;
            _levelButtons[i].interactable = true;
        }
    }
}