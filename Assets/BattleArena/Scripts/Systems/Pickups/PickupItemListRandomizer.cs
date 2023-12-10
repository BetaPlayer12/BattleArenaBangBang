using BattleArena;
using UnityEngine;

[System.Serializable]
public class PickupItemListRandomizer
{
    [System.Serializable]
    private class Info
    {
        [SerializeField]
        public float m_pickRate;
        [SerializeField]
        public PickupItemListData m_data;
    }

    [SerializeField]
    private Info[] m_handles;

    public PickupItem GetRandomItem()
    {
        var chance = UnityEngine.Random.Range(0, 100f);
        for (int i = 0; i < m_handles.Length; i++)
        {
            if(chance <= m_handles[i].m_pickRate)
            {
                var data = m_handles[i].m_data;
                var chosenItemIndex = UnityEngine.Random.Range(0, m_handles[i].m_data.count);
                return data.GetItem(chosenItemIndex);
            }

            chance -= m_handles[i].m_pickRate;
        }
        return null;
    }
}
