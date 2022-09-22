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
        [SerializeField] private TextMeshProUGUI killCountTxt;
        [SerializeField] private TextMeshProUGUI gameOverKillCountTxt;

        [Header("PlayerHealth")]
        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private TextMeshProUGUI healthTxt;
        [SerializeField] private GameObject bloodPanel;
        [SerializeField] private float bloodPanelActiveTime;
        [SerializeField] private Image sliderFillImg;
        [SerializeField] private float sliderShowTime;
        [SerializeField] private Color sliderStartColor = Color.green;
        [SerializeField] private Color sliderEndColor = Color.red;

        private bool isPaused;
        private EventHandler eventHandler;
        private int killCount=0;
        private const string KILL_TXT = "Zombies Killed : ";

        private void Start()
        {
            killCount = 0;
            bloodPanel.SetActive(false);
            pauseMenu.SetActive(false);
            gameOverMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
            killCountTxt.text = KILL_TXT + killCount;
            AssignEvents();
        }

        private void AssignEvents()
        {
            eventHandler = EventHandler.Instance;
            eventHandler.OnEnemyDead += OnEnemykilled;
            eventHandler.OnGameOver += OnGameOver;
            eventHandler.OnPlayerTookDamage += OnPlayerHealthChanged;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        public void OnGameOver()
        {
            gameOverMenu.SetActive(true);
            gameOverKillCountTxt.text = killCountTxt.text;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
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
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        public void Resume()
        {      
            if(isPaused)
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isPaused = false;
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnEnemykilled()
        {
            killCount++;
            killCountTxt.text = KILL_TXT + killCount;
        }
        private void OnPlayerHealthChanged(float amount)
        {
            if(amount>0f)
            {
                playerHealthSlider.value -= amount;
                bloodPanel.SetActive(true);
                Invoke(nameof(DisableBloodPanel),bloodPanelActiveTime);
            }
            healthTxt.text = playerHealthSlider.value.ToString();
            sliderFillImg.color = Color.Lerp(sliderEndColor,sliderStartColor, playerHealthSlider.value/playerHealthSlider.maxValue);
        }
        private void DisableBloodPanel()
        {
            bloodPanel.SetActive(false);
        }

        private void OnDisable()
        {
            eventHandler.OnEnemyDead -= OnEnemykilled;
            eventHandler.OnGameOver -= OnGameOver;
            eventHandler.OnPlayerTookDamage -= OnPlayerHealthChanged;
        }
    }
}
