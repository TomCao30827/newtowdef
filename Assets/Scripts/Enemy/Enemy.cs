using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CT239_TowDef
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int goldReward = 500;
        [SerializeField] private Currency currency;
        [SerializeField] private LivesManager livesManager;
        void Awake()
        {
            currency = FindObjectOfType<Currency>();
            livesManager = FindObjectOfType<LivesManager>();
        }

        public void Reward()
        {
            if (currency == null) return;
            currency.AddMoney(goldReward);
        }

        public void ReducePlayerHealth()
        {
            if (livesManager == null) return;
            livesManager.ReduceLives();
        }
    }
}
