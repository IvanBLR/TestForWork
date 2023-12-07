using UnityEngine;

public class Gifts : MonoBehaviour
{
    [SerializeField] private Sprite[] _gifts;

    public Sprite GetGiftIcon(int index)
    {
        if (index < _gifts.Length) return _gifts[index];
        return _gifts[0];
    }
}