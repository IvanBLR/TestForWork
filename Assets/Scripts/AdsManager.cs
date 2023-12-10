using System;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public Action LifeAdded;
    [SerializeField] private PurchasesController _purchasesController;

    private void Start()
    {
        _purchasesController.LifeAdded += OnLifeAdded;
    }

    private void OnDestroy()
    {
        _purchasesController.LifeAdded -= OnLifeAdded;
    }

    private void OnLifeAdded()
    {
        LifeAdded?.Invoke();
    }
}