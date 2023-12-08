using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BonusController : MonoBehaviour
{
    [SerializeField] private Canvas _bonusCanvas;
    [SerializeField] private Image _sorryText;
    [SerializeField] private Button _gift;


    private bool _isBonusButtonInteractable;
    private bool _isSorryAnimationPlaying;
    private Color _primeColor;

    private void Awake()
    {
        _primeColor = _sorryText.color;
        _sorryText.gameObject.SetActive(false);
    }

    [UsedImplicitly] // назначен на кнопку подарка. Если бонус ещё не начислен, активируется извиняшка
    public void ActivateSorryText()
    {
        if (!_isBonusButtonInteractable)
        {
            StartCoroutine(ShowSorryViewEffect());
        }
    }

    public void ActivateBonusAnimation()
    {
    }

    public void ActivateBonusMenu(bool needActivate) => _bonusCanvas.gameObject.SetActive(needActivate);

    private IEnumerator ShowSorryViewEffect()
    {
        _gift.gameObject.SetActive(false);
        _sorryText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _sorryText.DOFade(0.35f, 2f)
            .SetDelay(0.1f)
            .OnComplete(OnCompleteSorryAnimation);
    }

    private void OnCompleteSorryAnimation()
    {
        _sorryText.gameObject.SetActive(false);
        _sorryText.color = _primeColor;
        _gift.gameObject.SetActive(true);
        _isSorryAnimationPlaying = false;
    }
}