using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChecker : MonoBehaviour
{
    string mainMenuScene = "MainMenu";
    string LevelOneIntro = "IntroLevelOneAnimation";
    string LevelOne = "LevelOneActual";
    string LevelOneOutro = "OutroLevelOneAnimation";
    string LevelTwoIntro = "LvlTwoProto";
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

        if (SceneManager.GetActiveScene().name == LevelOneOutro)
        {
            Invoke("LoadLevelTwoIntro", 5f);
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



}
