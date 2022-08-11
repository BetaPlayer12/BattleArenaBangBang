using System.Collections;
using UnityEngine;

namespace BattleArena.Nonami.FlameThrower
{
   
    public class Flame : MonoBehaviour
    {
       
        [SerializeField]
        private GameObject Scorched;
        private bool spawn=false;
        public void Start()
        {
            StartCoroutine(ScorchDeathCoroutine());
        }
        IEnumerator ScorchDeathCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            spawn = true;
        }
        private void FixedUpdate()
        {
            if (spawn == true)
            {
                GameObject InstantiatedGameObject = Instantiate(Scorched);
                InstantiatedGameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            

        }
       
    }

}
