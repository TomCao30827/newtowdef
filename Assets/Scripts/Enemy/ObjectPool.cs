using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CT239_TowDef
{
    public class ObjectPool : MonoBehaviour
    {
        /// <summary>
        /// The prefabs of the enemy to spawn
        /// </summary>
        [SerializeField] private GameObject enemyPrefabs;

        /// <summary>
        /// The time delay between spawn
        /// </summary>
        [SerializeField] private float spawnTimer = 1.0f;


        void Start ()
        {
            StartCoroutine(SpawnEnemy());
        }

        IEnumerator SpawnEnemy()
        {
            while (!GameManager.isGameOver)
            {
                Instantiate(enemyPrefabs, transform);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
    }
}
