using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CT239_TowDef
{
    public class Currency : MonoBehaviour
    {
        /// <summary>
        /// The money player gains when start game
        /// </summary>
        [SerializeField] private int startingMoney = 200;

        /// <summary>
        /// The current amount of money the player has
        /// </summary>
        [SerializeField]int currentMoney;

        [SerializeField] private TextMeshProUGUI textMoney;

        /// <summary>
        /// Get the value of player's current money
        /// </summary>
        public int CurrentMoney { get { return currentMoney; }}

        private void Awake()
        {
            currentMoney = startingMoney;
        }

        private void Update()
        {
            DisplayMoney();
        }

        /// <summary>
        /// Add an amount of money to player
        /// </summary>
        /// <param name="amount"></param>
        public void AddMoney(int amount)
        {
            currentMoney += Mathf.Abs(amount);
        }

        /// <summary>
        /// Decrease an amount of money to player
        /// </summary>
        /// <param name="amount"></param>
        public void DecreaseMoney(int amount)
        {
            currentMoney -= Mathf.Abs(amount);
        }


        /// <summary>
        /// Show the current amount of money
        /// </summary>
        public void DisplayMoney()
        {
            textMoney.text = "Gold: " + currentMoney.ToString();
        }
    }
}
