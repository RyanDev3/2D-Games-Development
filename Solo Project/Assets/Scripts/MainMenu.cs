using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");
    }
    //public void TutorialGame()
    //{
    //    SceneManager.LoadScene("Tutorial");
    //}
    public void ExitGame()
    {
        Application.Quit();
    }
}
