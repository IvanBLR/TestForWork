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
    public Action<int> DailyBonusGot;

    [SerializeField] private Canvas _bonusCanvas;
    [SerializeField] private Image _sorryText;
    [SerializeField] private Gifts _gifts;
    [SerializeField] private Button _giftButton;
    [SerializeField] private ParticleSystem _particleSystem;


    private bool _isBonusButtonInteractable;
    private bool _isSorryAnimationPlaying;
    private Color _primeColor;
    private RectTransform _buttonRectTransform;

    private void Awake()
    {
        _primeColor = _sorryText.color;
        _sorryText.gameObject.SetActive(false);
        _buttonRectTransform = _giftButton.GetComponent<RectTransform>();
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
        _buttonRectTransform.DORotate(new Vector3(0, 0, 1080), 1, RotateMode.FastBeyond360)
            .OnComplete(OnCompleteBonusAnimation);
    }

    public void ActivateBonusMenu(bool needActivate) => _bonusCanvas.gameObject.SetActive(needActivate);

    private IEnumerator ShowSorryViewEffect()
    {
        _giftButton.gameObject.SetActive(false);
        _sorryText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _sorryText.DOFade(0.35f, 2f)
            .SetDelay(0.1f)
            .OnComplete(OnCompleteSorryAnimation);
    }

    private void OnCompleteBonusAnimation()// TODO: надо доделать получениие награды. Use script Gifts
    {
        _particleSystem.Play();
        DailyBonusGot?.Invoke(100);
        //StartCoroutine(ActivateBonusText());
    }

    private void OnCompleteSorryAnimation()
    {
        _sorryText.gameObject.SetActive(false);
        _sorryText.color = _primeColor;
        _giftButton.gameObject.SetActive(true);
        _isSorryAnimationPlaying = false;
    }
    //
    // private IEnumerator ActivateBonusText()
    // {
    //     _bonusText.gameObject.SetActive(true);
    //     yield return new WaitForSeconds(2);
    //     _bonusText.gameObject.SetActive(false);
    // }
}