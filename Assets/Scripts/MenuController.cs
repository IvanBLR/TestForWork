using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Canvas _menu;

    public void ActivateMainMenu(bool needActivate) => _menu.gameObject.SetActive(needActivate);
}