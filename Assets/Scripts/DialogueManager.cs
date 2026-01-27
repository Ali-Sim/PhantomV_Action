using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Rendering.MaterialUpgrader;

public class DialogueManager : MonoBehaviour
{
    //CSV Finder
    public TextAsset csvDialogue;
    public string[,] dialougeGrid;

    //Diolouge Box
    public GameObject dialougeBox;
    public TMP_Text dialougeTxt, nameTxt;
    public float dialogueType = 0.025f;
    public GameObject SpeakingFace;

    //DialougeVariables
    public bool canTalk, startedPlaying, currentlyPlaying, donePlaying;
    public bool doneTyping, textBoxOpen;
    public string commaCheckTxt;
    public string commaCheckName;

    //Indexes
    public int characterID;
    public int currentTextIndex;
    public int lengthOfDialouge;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //How to call items in the CSV - grid[x, y] where x and y are numbers starting from 0 (A1 on the excel sheet would be 0,0 and A2 on the excell sheet would be 0,1)
        //How to call certain characters - grid[2 + currentTextIndex, characterID]
        csvDialogue = Resources.Load<TextAsset>("CSVFiles/TestingDialouge02");
        dialougeGrid = getCSVGrid(csvDialogue.text);

        dialougeBox.SetActive(false);
        textBoxOpen = false;

        characterID = 1;
        currentTextIndex = 0;

        doneTyping = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && textBoxOpen)
        {
            ClickForward();
        }
    }

    public string[,] getCSVGrid(string csvText)
    {
        //split the data on split line character
        string[] lines = csvText.Split("\n"[0]);

        // find the max number of columns
        int totalColumns = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(',');
            totalColumns = Mathf.Max(totalColumns, row.Length);
        }

        // creates new 2D string grid to output to
        string[,] outputGrid = new string[totalColumns + 1, lines.Length + 1];
        for (int y = 0; y < lines.Length; y++)
        {
            string[] row = lines[y].Split(',');

            for (int x = 0; x < row.Length; x++)
            {
                outputGrid[x, y] = row[x];
            }
        }

        return outputGrid;
    }

    public IEnumerator Dialogue(string message)
    {
        //pick message to show
        dialougeTxt.text = "";
        string newDialogue = message;

        doneTyping = false;


        //type out message
        foreach (char c in newDialogue)
        {
            dialougeTxt.text += c;
            yield return new WaitForSeconds(dialogueType);
        }

        doneTyping = true;


    }

    public void OpenTextBox(int characterIndex)
    {
        textBoxOpen = true;
        currentTextIndex = 0;
        characterID = characterIndex;
        doneTyping = false;
        dialougeBox.SetActive(true);
        PlayDio();
    }

    public void ClickForward()
    {
        Debug.Log(currentTextIndex);
        Debug.Log(dialougeGrid[currentTextIndex + 3, characterID]);
        string EndCheck = dialougeGrid[currentTextIndex + 3, characterID];
        Debug.Log(EndCheck);

        if (dialougeGrid[currentTextIndex + 3, characterID] == "END TEXT" || dialougeGrid[currentTextIndex + 3, characterID] == null || dialougeGrid[currentTextIndex + 3, characterID] == "END TEXT\r\n")
        {
            Debug.Log("Attempting To Close");
            CloseTextBox();
        }
        else
        {
            if (doneTyping)
            {
                currentTextIndex += 1;
            }

            PlayDio();
        }
        
        

    }

    public void ClickBackwards()
    {

    }

    public void CloseTextBox()
    {
        dialougeBox.SetActive(false);
        textBoxOpen = false;
    }

    void PlayDio() //plays the dialouge inside the text box depending on the character ID and page index
    {
        commaCheckName = dialougeGrid[1, characterID];
        commaCheckName = commaCheckName.Replace("`", ",");

        commaCheckTxt = dialougeGrid[currentTextIndex + 2, characterID];
        commaCheckTxt = commaCheckTxt.Replace("`", ",");

        if (doneTyping) //if the player clicks the button after typing, move to the next text dialouge
        {
            StopAllCoroutines();
            nameTxt.text = commaCheckName;
            StartCoroutine(Dialogue(commaCheckTxt));

        }

        else //if they click forwards before the text types, skip to the end and finish the text
        {
            doneTyping = true;
            StopAllCoroutines();
            nameTxt.text = commaCheckName;
            dialougeTxt.text = commaCheckTxt;
        }

        ChangeCharacter();
    }

    void ChangeCharacter()
    {
        switch (characterID)
        {
            case 1:
                SpeakingFace.GetComponent<Image>().sprite = Resources.Load<Sprite>("GoodWizard");
                break;
            case 2:
                SpeakingFace.GetComponent<Image>().sprite = Resources.Load<Sprite>("BadWizard");
                break;


        }
    }

    public void DebugOne()
    {
        OpenTextBox(1);
    }

    public void DebugTwo()
    {
        OpenTextBox(2);
    }
}

