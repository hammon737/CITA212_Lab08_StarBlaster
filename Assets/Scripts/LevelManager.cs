using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOverMenu", 2f));
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
