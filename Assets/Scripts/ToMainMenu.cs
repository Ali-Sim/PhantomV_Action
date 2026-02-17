using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    private void Start()
    {
        Invoke("MainMenu", 5f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
