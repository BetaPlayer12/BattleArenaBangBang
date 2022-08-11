using BattleArena;
using System.Collections;
using UnityEngine;

public class TrollMonkey : WizardMonkey
{
    [SerializeField]
    private GameObject m_toInstantiate;

    protected override void Pickup(Collider2D collision)
    {
        var instance = Instantiate(m_toInstantiate);
        instance.transform.position = Vector3.zero;
        base.Pickup(collision);
        StartCoroutine(DisappearItemsRoutine());
    }

    private IEnumerator DisappearItemsRoutine()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1.333f);
        RemoveAllBullets();
        DestroyAllPickups();
        Destroy(gameObject);
    }

    private void DestroyAllPickups()
    {
        var pickupItems = FindObjectsOfType<PickupItem>();
        for (int i = pickupItems.Length - 1; i >= 0; i--)
        {
            var pickupItem = pickupItems[i];
            if (pickupItem != this)
            {
                Destroy(pickupItem.gameObject);
            }
        }
    }

    private static void RemoveAllBullets()
    {
        var bullets = FindObjectsOfType<Bullet>();
        for (int i = bullets.Length - 1; i >= 0; i--)
        {
            var bullet = bullets[i];
            bullet.ForceCollision();
            if (bullet.gameObject != null)
            {
                Destroy(bullet.gameObject);
            }

        }
    }
}
