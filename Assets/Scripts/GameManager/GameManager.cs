using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CT239_TowDef
{

    public class GameManager : MonoBehaviour
    {
        private int playerMaxHealth = 5;
        private static GameManager instance;
        [SerializeField] private GameObject gameOver;
        public static bool isGameOver = false;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }


        }


        public void LoseGame()
        {
            isGameOver = true;
            gameOver.SetActive(true);
                
        }


        public void RestartGame()
        {
            isGameOver = false;
            gameOver.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
