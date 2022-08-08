using BattleArena;
using UnityEngine;

[CreateAssetMenu(fileName = "PickupListData",menuName = "BattleArenaBangBang/PickupItemList")]
public class PickupItemListData : ScriptableObject
{
    [SerializeField]
    private PickupItem[] m_items;

    public int count => m_items.Length;
    public PickupItem GetItem(int index) => m_items[index];
}
