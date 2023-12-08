using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private List<Map> m_maps;
        [SerializeField]
        private Transform m_playField;

        public void SelectMap(Image mapIcon)
        {
            StartCoroutine(RandomMapSelect(mapIcon));
        }

        private void SpawnSelectedMap(GameObject map)
        {
            Instantiate(map).transform.SetParent(m_playField);
        }

        private IEnumerator RandomMapSelect(Image icon)
        {
            int secondsOfSelecting = (int)Random.Range(5, 10);
            int chosenMap = 0;

            for(int i = 0; i <= secondsOfSelecting; i++)
            {
                int randomChoice = (int)Random.Range(0, m_maps.Count);
                icon.sprite = m_maps[randomChoice].mapIcon.sprite;
                chosenMap = randomChoice;

                yield return new WaitForSeconds(0.3f);               
            }
            icon.sprite = m_maps[chosenMap].mapIcon.sprite;
            SpawnSelectedMap(m_maps[chosenMap].gameObject);
        }
    }

}
