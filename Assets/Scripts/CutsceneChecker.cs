
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChecker : MonoBehaviour
{
    string mainMenuScene = "MainMenu";
    string LevelOneIntro = "IntroLevelOneAnimation";
    string LevelOne = "LevelOneActual";
    string LevelOneOutro = "OutroLevelOneAnimation";
    string LevelTwoIntro = "IntroLevelTwo";
    string LevelTwo = "LvlTwoProto";
    string LevelTwoOutro = "OutroLevelTwo";
    string LevelThreeIntro = "Credits";
    string LevelThree = "N/A";
    string LevelThreeOutro = "Controls";
    string winScene = "WIN";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == LevelOneIntro)
        {
            Invoke("LoadLevelOne",24.5f);
        }

        if (SceneManager.GetActiveScene().name == LevelOneOutro)
        {
            Invoke("LoadLevelTwoIntro", 5f);
        }

        if (SceneManager.GetActiveScene().name == LevelTwoIntro)
        {
            Invoke("LoadLevelTwo", 30f);
        }

        if (SceneManager.GetActiveScene().name == LevelTwoOutro)
        {
            Invoke("LoadLevelThreeIntro", 7f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "EndOfTutorialTrigger":
                if (SceneManager.GetActiveScene().name == LevelOne)
                {
                    LoadLevelOneEnd();
                }
                else if (SceneManager.GetActiveScene().name == LevelTwoIntro)
                {
                    SceneManager.LoadScene(winScene);
                }
                    break;

        }
    }

    void LoadLevelOne()
    {
        SceneManager.LoadScene(LevelOne);
    }

    void LoadLevelTwoIntro()
    {
        SceneManager.LoadScene(LevelTwoIntro);
    }

    void LoadLevelOneEnd()
    {
        SceneManager.LoadScene(LevelOneOutro);
    }

    void LoadLevelTwo()
    {
        SceneManager.LoadScene(LevelTwo);
    }

    void LoadLevelThreeIntro()
    {
        SceneManager.LoadScene(winScene);
    }


}
