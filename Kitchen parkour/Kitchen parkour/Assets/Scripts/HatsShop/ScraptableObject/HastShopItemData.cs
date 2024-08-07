using UnityEngine;

[CreateAssetMenu(fileName = "Hat", menuName = "GameDesign/HatShopItem")]
public class HastShopItemData : ScriptableObject
{
    [SerializeField] private GameObject _hatPrefab;
    [SerializeField][Min(1)] private int _cost = 10;

    public GameObject hatPrefab => _hatPrefab;
    public int cost => _cost;
}