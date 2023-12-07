using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private Canvas _levels;

    public void ActivateLevelsMenu(bool needActivate) => _levels.gameObject.SetActive(needActivate);
}