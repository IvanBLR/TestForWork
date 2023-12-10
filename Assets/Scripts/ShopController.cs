using System.Collections;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject _attention;

    [SerializeField] private Canvas _shop;

    [SerializeField] private Button _lifeButton;
    [SerializeField] private Button _allTimeSkillButton;

    [SerializeField] private Button[] _purchases;
    [SerializeField] private Button[] _tempButtons;

    private void Start()
    {
        //PlayerPrefs.SetInt(GameConstants.LONG_LIFE, 0);// эта строчка для сброса удлинённой жизни
        UpdateShopButtons();
    }

    public void ActivateShopMenu(bool needActivate) => _shop.gameObject.SetActive(needActivate);

    [UsedImplicitly] // назначен на временные кнопки для активации предупреждения
    public void ActivateAttentionText()
    {
        StartCoroutine(StartAttention());
    }

    public void DeactivateButton()
    {
        _lifeButton.interactable = false;
    }

    private IEnumerator StartAttention()
    {
        _attention.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        _attention.gameObject.SetActive(false);
    }

    private void UpdateShopButtons()
    {
        int indexForUnblockTempButton = PlayerPrefs.GetInt(GameConstants.LAST_UNLOCKED_LEVEL) / 5 - 1;
        for (int i = 0; i < indexForUnblockTempButton; i++)
        {
            _tempButtons[i].gameObject.SetActive(false);
            _purchases[i].interactable = true;
        }

        int life = PlayerPrefs.GetInt(GameConstants.LONG_LIFE);
        if (life == 1)
            _lifeButton.interactable = false;

        int skill = PlayerPrefs.GetInt(GameConstants.ALL_TIME_SKILL);
        if (skill == 1)
            _allTimeSkillButton.interactable = false;
    }
}