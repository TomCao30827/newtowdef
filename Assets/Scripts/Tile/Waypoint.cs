using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CT239_TowDef
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private bool isPlacable;
        [SerializeField] private Tower towerPrefabs;

        public bool IsPlacable { get { return isPlacable; } }

        private void OnMouseDown()
        {
            if (isPlacable && !GameManager.isGameOver)
            {
                bool placed = towerPrefabs.CreateTower(towerPrefabs, transform.position);
                isPlacable = !placed;
            }
        }
    }
}
