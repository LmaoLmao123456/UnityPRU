using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    public static bool hasKey = false;
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentEnergy;
    [SerializeField] private int energyThreshHold = 3;
    [SerializeField] private GameObject boss;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OverMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject ContinueLevel;

    void Start()
    {
        Mainmenu();
        LoadScore();
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        UpdateScore();
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "SampleScene")
        {
            
            MainMenu?.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
           
            MainMenu?.SetActive(false);
            Time.timeScale = 1f;
        }
    }



    public void AddScore(int points)
    {
        score += points;
        UpdateScore();

    }

    public void AddEnergy()
    {
        if (bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        UpdateEnergyBar();
        if (currentEnergy == energyThreshHold)
        {
            CallBoss();
        }
    }
    private void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        gameUI.SetActive(false);
    }
    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshHold);
            energyBar.fillAmount = fillAmount;
        }
    }
    // L?u ?i?m tr??c khi chuy?n scene
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }


    // Chuy?n qua màn m?i
    public void NextLevel(string sceneName)
    {
        SaveScore();
        SceneManager.LoadScene(sceneName);
    }


    // Khi scene m?i load xong, gán l?i UI m?i
    public void SetScoreUI(TextMeshProUGUI newScoreText)
    {
        scoreText = newScoreText;
        UpdateScore();
    }
    public void Mainmenu()
    {
        ContinueLevel.SetActive(false);
        MainMenu.SetActive(true);
        OverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Ovemenu()
    {
        ContinueLevel.SetActive(false);
        OverMenu.SetActive(true);
        MainMenu.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Pausemenu()
    {
        ContinueLevel.SetActive(false);
        PauseMenu.SetActive(true);
        OverMenu.SetActive(false);
        MainMenu.SetActive(false);
        Time.timeScale = 0f;

    }
    public void StartGAme()
    {
        ContinueLevel.SetActive(false);
        PauseMenu.SetActive(false);
        OverMenu.SetActive(false);
        MainMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    public void ResumeGame()
    {
        ContinueLevel.SetActive(false);
        PauseMenu.SetActive(false);
        OverMenu.SetActive(false);
        MainMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    public void continueLevel()
    {
        ContinueLevel.SetActive(true);
        PauseMenu.SetActive(false);
        OverMenu.SetActive(false);
        MainMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteKey("Score"); // xoá điểm đã lưu
        score = 0;
        UpdateScore();

        // Reset năng lượng và boss
        currentEnergy = 0;
        bossCalled = false;
        UpdateEnergyBar();
        boss?.SetActive(false);
        gameUI?.SetActive(true);

        // UI
        ContinueLevel?.SetActive(false);
        MainMenu?.SetActive(false);
        OverMenu?.SetActive(false);
        PauseMenu?.SetActive(false);
        Time.timeScale = 1f;
    }

}
