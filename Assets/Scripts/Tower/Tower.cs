using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CT239_TowDef
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int cost = 50;
        public bool CreateTower(Tower tower, Vector3 position)
        {
            Currency currency = FindObjectOfType<Currency>();

            if (currency == null)
            {
                return false;
            }

            if (currency.CurrentMoney >= cost)
            {
                Instantiate(tower.gameObject, position, Quaternion.identity);
                currency.DecreaseMoney(cost);
                return true;
            }

            return false;

        }
    }
}
