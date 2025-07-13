using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameManger gameManger;
    public void StartGame()
    {
        gameManger.StartGAme();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ContinueGame()
    {
        gameManger.ResumeGame();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f; // Phải có
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
