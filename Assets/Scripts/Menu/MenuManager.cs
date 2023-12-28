using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CT239_TowDef
{
    public class MenuManager : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadSceneAsync("TheGame");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
