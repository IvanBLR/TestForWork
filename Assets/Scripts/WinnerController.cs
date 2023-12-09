using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerController : MonoBehaviour
{
    private int _currentLevel;

    private void Start()
    {
        _currentLevel = PlayerPrefs.GetInt(GameConstants.LAST_UNLOCKED_LEVEL);
    }

    [UsedImplicitly] // назначен на кнопку победы
    public void UnlockNextLevel()
    {
        PlayerPrefs.SetInt(GameConstants.LAST_UNLOCKED_LEVEL, _currentLevel + 1);
        SceneManager.LoadScene(0);
    }
}
