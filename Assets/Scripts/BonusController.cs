using UnityEngine;

public class BonusController : MonoBehaviour
{
    [SerializeField] private Canvas _bonus;

    public void ActivateBonusMenu(bool needActivate) => _bonus.gameObject.SetActive(needActivate);
}