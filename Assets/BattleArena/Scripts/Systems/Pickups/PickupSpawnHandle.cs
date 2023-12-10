using BattleArena;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnHandle : MonoBehaviour
{
    [SerializeField]
    private PickupItemListRandomizer m_itemRandomizer;
    [SerializeField]
    private Collider2D m_spawnArea;
    [SerializeField]
    private int m_maxSpawnedItems;
    [SerializeField, BoxGroup("SpawnRate")]
    private float m_minSpawnRate;
    [SerializeField, BoxGroup("SpawnRate")]
    private float m_maxSpawnRate;

    private float m_spawnTimer;
    private int m_spawnedItemsCount;
    private List<PickupItem> m_spawnedItems;

    private float GenerateSpawnRate() => UnityEngine.Random.Range(m_minSpawnRate, m_maxSpawnRate);

    private void SpawnItem()
    {
        var chosenItem = m_itemRandomizer.GetRandomItem();
        var instance = Instantiate(chosenItem.gameObject).GetComponent<PickupItem>();
        m_spawnedItems.Add(instance);
        instance.PickedUp += OnItemPickup;
        instance.transform.position = GetRandomSpawnPoint();
        m_spawnedItemsCount++;
    }

    private Vector2 GetRandomSpawnPoint()
    {
        var bounds = m_spawnArea.bounds;
        var extents = bounds.extents;
        var center = (Vector2)bounds.center;
        var offset = new Vector2(GetRandomOffset(extents.x), GetRandomOffset(extents.y));

        return center + offset;
        float GetRandomOffset(float extent)
        {
            return UnityEngine.Random.Range(-extent, extent);
        }
    }

    private void OnItemPickup(PickupItem obj)
    {
        obj.PickedUp -= OnItemPickup;
        m_spawnedItems.Remove(obj);
        m_spawnedItemsCount--;
    }

    private void Awake()
    {
        m_spawnTimer = GenerateSpawnRate();
        m_spawnedItems = new List<PickupItem>();
    }

    private void Update()
    {
        if (m_spawnedItemsCount < m_maxSpawnedItems)
        {
            if (m_spawnTimer <= 0)
            {
                SpawnItem();
                m_spawnTimer = GenerateSpawnRate();
            }
        }

        m_spawnTimer -= Time.deltaTime;
    }

    public void Reset()
    {
        for (int i = m_spawnedItems.Count - 1; i >= 0; i--)
        {
            Destroy(m_spawnedItems[i].gameObject);
        }
    }
}
