using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void TutorialGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
