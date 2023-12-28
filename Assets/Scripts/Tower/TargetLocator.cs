using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CT239_TowDef
{
    public class TargetLocator : MonoBehaviour
    {
        /// <summary>
        /// Get the enemy transform
        /// </summary>
        [SerializeField] private Transform target;

        /// <summary>
        /// Get the weapon transform
        /// </summary>
        [SerializeField] private Transform weapon;
        
        /// <summary>
        /// Range of the weapon
        /// </summary>
        [SerializeField] private float range;

        /// <summary>
        /// Projectile using particle system
        /// </summary>
        [SerializeField] private ParticleSystem projectileParticle;        
        void Start()
        {
            target = FindObjectOfType<EnemyMover>().transform;
        }

        void Update()
        {
            FindClosetTarget();
            AimWeapon();
        }

        /// <summary>
        /// Find the closet enemy
        /// </summary>
        private void FindClosetTarget()
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            Transform closetTarget = null;
            float maxDistance = Mathf.Infinity;

            foreach (Enemy enemy in enemies)  //Loop the array to choose the closet
            {
                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (targetDistance < maxDistance)
                {
                    closetTarget = enemy.transform;
                    maxDistance = targetDistance;
                }
            }
            target = closetTarget;
        }

        /// <summary>
        /// Rotate the weapon to the enemy location
        /// </summary>
        private void AimWeapon()
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
            weapon.LookAt(target);

            if (targetDistance <= range)
            {
                Attack(true);
            }
            else Attack(false);
        }

        private void Attack(bool isActive)
        {
            var emissionModule = projectileParticle.emission;
            emissionModule.enabled = isActive;
        }
    }
}
