using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CT239_TowDef
{
    public class LivesManager : MonoBehaviour
    {
        [SerializeField] private int playerLives = 5;
        [SerializeField] private TextMeshProUGUI livesText;
        public int playerCurrentLives;

        private void Awake()
        {
            playerCurrentLives = playerLives;
        }

        private void Update()
        {
            DisplayLives();
        }

        private void DisplayLives()
        {
            livesText.text = "Lives: " + playerCurrentLives;
        }

        public void ReduceLives()
        {
            if (playerCurrentLives == 1)
            {
                GameManager.Instance.LoseGame();
            }
            else
            {
                playerCurrentLives--;
            }
        }
    }
}
