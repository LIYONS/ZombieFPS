using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieFPS.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int gameBIndex;
        
        public void StartGame()
        {
            SceneManager.LoadScene(gameBIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
