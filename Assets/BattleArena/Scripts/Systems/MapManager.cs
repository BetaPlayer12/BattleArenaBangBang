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
        private int m_timesToIterateMaps;

        public void SelectMap(Image mapIcon)
        {
            StartCoroutine(RandomMapSelect(mapIcon));
        }

        public void ResetMapSelection(Image mapIcon)
        {
            mapIcon.sprite = null;
        }

        private void SpawnSelectedMap(GameObject map)
        {
            Instantiate(map).transform.SetParent(m_playField);
        }

        private IEnumerator RandomMapSelect(Image icon)
        {
            int chosenMap = 0;
            int timesToGoThroughMaps = m_timesToIterateMaps;

            while(timesToGoThroughMaps > 0)
            {
                if(timesToGoThroughMaps > 1)
                {
                    for (int c = 0; c < m_maps.Count; c++)
                    {
                        icon.sprite = m_maps[c].mapIcon;
                        chosenMap = c;

                        yield return new WaitForSeconds(0.3f);
                    }
                }
                else
                {
                    int randomChoice = Random.Range(0, m_maps.Count);
                    icon.sprite = m_maps[randomChoice].mapIcon;
                    chosenMap = randomChoice;
                    yield return new WaitForSeconds(0.3f);
                }
                

                timesToGoThroughMaps--;
            }

            icon.sprite = m_maps[chosenMap].mapIcon;
            SpawnSelectedMap(m_maps[chosenMap].gameObject);
        }
    }

}
