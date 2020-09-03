using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    const int MAINMENU = 0;
    const int LAUNCHES = 1;
    const int ROADSTER = 2;

    public void MainMenu()
    {
        SceneManager.LoadScene(MAINMENU);
    }
    public void Launches()
    {
        SceneManager.LoadScene(LAUNCHES);
    }
    public void Roadster()
    {
        SceneManager.LoadScene(ROADSTER);
    }
    public void QuitApp()
    {
        Debug.Log("Closing the app.");
        Application.Quit();
    }

}
