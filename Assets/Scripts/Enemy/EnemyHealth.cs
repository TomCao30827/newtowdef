using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CT239_TowDef
{

    [RequireComponent(typeof(Enemy))]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int enemyMaxHeatlh = 5;
        [SerializeField] private int currentHealth = 0;
        private Enemy enemy;

        private void Start()
        {
            currentHealth = enemyMaxHeatlh;
            enemy = GetComponent<Enemy>();
        }

        private void OnParticleCollision(GameObject other)
        {
            Debug.Log("Hit");
            HitProjectile();
        }

        private void HitProjectile()
        {
            if (currentHealth == 1) 
            {
                enemy.Reward();
                Destroy(gameObject);
            }
            else currentHealth--;
        }
    }
}
