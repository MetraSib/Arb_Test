using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanelScript : MonoBehaviour
{
    [SerializeField] private GameObject gamePausePanel;

    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        PlayerController.Singleton.DieEvent += GameOverPanel;
    }

    public void PauseMenu() 
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
    }

    public void ContinueGame() 
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
    }

    public void BackMainMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void GameOverPanel() 
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Restart() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
