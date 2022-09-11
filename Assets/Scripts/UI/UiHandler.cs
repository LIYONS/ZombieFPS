using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ZombieFPS.UI
{
    public class UiHandler : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject gameOverMenu;


        [Header("GameElements")]
        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private TextMeshProUGUI killCountTxt;
        [SerializeField] private Image sliderFillImg;
        private bool isPaused;

        private void Start()
        {
            pauseMenu.SetActive(false);
            gameOverMenu.SetActive(false);
            isPaused = false;
        }


        public void QuitGame()
        {
            Application.Quit();
        }

        public void PauseGame()
        {
            if(isPaused)
            {
                Resume();
                return;
            }
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {      
            if(isPaused)
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                isPaused = false;
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
