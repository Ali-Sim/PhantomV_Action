using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChecker : MonoBehaviour
{
    string mainMenuScene = "MainMenu";
    string LevelOneIntro = "IntroLevelOneAnimation";
    string LevelOne = "LevelOneActual";
    string LevelOneOutro = "AlejandroTest";
    string LevelTwoIntro = "MarcusTestScene";
    string LevelTwoOutro = "SOUNDSMarcusTest";
    string LevelThreeIntro = "Credits";
    string LevelThreeOutro = "Controls";
    string winScene = "WIN";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == LevelOneIntro)
        {
            Invoke("LoadLevelOne",24.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevelOne()
    {
        SceneManager.LoadScene(LevelOne);
    }
}
