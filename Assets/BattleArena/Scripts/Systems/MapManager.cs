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
        [SerializeField]
        private int m_mapSelectTime;

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
            int chosenMap = 0;
            int timesToGoThroughMaps = m_mapSelectTime;

            while(timesToGoThroughMaps > 0)
            {
                for(int c = 0; c < m_maps.Count; c++)
                {
                    int skipDecider = Random.Range(0, 2);

                    if (skipDecider == 0)
                        break;

                    icon.sprite = m_maps[c].mapIcon.sprite;
                    chosenMap = c;

                    yield return new WaitForSeconds(0.3f);
                }

                timesToGoThroughMaps--;
            }

            icon.sprite = m_maps[chosenMap].mapIcon.sprite;
            SpawnSelectedMap(m_maps[chosenMap].gameObject);
        }
    }

}
