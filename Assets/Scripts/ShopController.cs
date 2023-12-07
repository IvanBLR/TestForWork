using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Canvas _shop;

    public void ActivateShopMenu(bool needActivate) => _shop.gameObject.SetActive(needActivate);
}