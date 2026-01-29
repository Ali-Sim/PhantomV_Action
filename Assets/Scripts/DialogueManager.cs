using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    public float inBetweenNumber = 0.01f ;

    //Indexes
    public int characterID;
    public int currentTextIndex;
    public int lengthOfDialouge;
    public Coroutine dioCor;

    //Targets + Sheild
    public GameObject SpellCastingVariable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //How to call items in the CSV - grid[x, y] where x and y are numbers starting from 0 (A1 on the excel sheet would be 0,0 and A2 on the excell sheet would be 0,1)
        //How to call certain characters - grid[2 + currentTextIndex, characterID]
        csvDialogue = Resources.Load<TextAsset>("CSVFiles/ActualDialogue");
        dialougeGrid = getCSVGrid(csvDialogue.text);

        dialougeBox.SetActive(false);
        textBoxOpen = false;

        characterID = 1;
        currentTextIndex = 0;

        doneTyping = true;

        if (SceneManager.GetActiveScene().name == "LevelOneActual")
        {
            Lvl01Dio01FUNC();
        }

        if (SceneManager.GetActiveScene().name == "LvlTwoProto")
        {
            OpenTextBox(14);
        }

        SpellCastingVariable  = GameObject.Find("PlayerMain");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && textBoxOpen)
        {
            ClickForward();
        }

        if (SpellCastingVariable.GetComponent<SpellCasting>().TargetCount == 11)
        {
            
            Lvl01Dio02FUNC();
            SpellCastingVariable.GetComponent<SpellCasting>().TargetCount += 1;

        }

        if (SpellCastingVariable.GetComponent<SpellCasting>().FirstTimeShield == -1)
        {
            SpellCastingVariable.GetComponent<SpellCasting>().FirstTimeShield -= 1;
            Lvl01Dio03FUNC();   
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
        CloseTextBox();

        textBoxOpen = true;
        currentTextIndex = 0;
        characterID = characterIndex;
        doneTyping = true;
        dialougeBox.SetActive(true);
        PlayDio();
    }

    public void ClickForward()
    {
        Debug.Log(currentTextIndex);
        Debug.Log(dialougeGrid[currentTextIndex + 3, characterID]);
        string EndCheck = dialougeGrid[currentTextIndex + 3, characterID];
        Debug.Log(EndCheck);

        if ((dialougeGrid[currentTextIndex + 3, characterID] == "END TEXT" || dialougeGrid[currentTextIndex + 3, characterID] == null || dialougeGrid[currentTextIndex + 3, characterID] == "END TEXT\r\n") & doneTyping)
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

        if (doneTyping && currentTextIndex == 0) //if the player clicks the button after typing, move to the next text dialouge
        {
            nameTxt.text = commaCheckName;
            dioCor = StartCoroutine(Dialogue(commaCheckTxt));

        }

        else if (doneTyping)
        {
            nameTxt.text = commaCheckName;
            dioCor = StartCoroutine(Dialogue(commaCheckTxt));
        }

        else //if they click forwards before the text types, skip to the end and finish the text
        {
            doneTyping = true;
            StopCoroutine(dioCor);
            nameTxt.text = commaCheckName;
            dialougeTxt.text = commaCheckTxt;
        }

        ChangeCharacter();
    }

    void ChangeCharacter()
    {
        switch (nameTxt.text)
        {
            case "":
                SpeakingFace.GetComponent<Image>().sprite = Resources.Load<Sprite>("GoodWizard");
                break;
            case " ":
                SpeakingFace.GetComponent<Image>().sprite = Resources.Load<Sprite>("BadWizard");
                break;


        }
    }

    public IEnumerator Lvl01Dio01()
    {

        OpenTextBox(1);

        textBoxOpen = true;


        while (textBoxOpen)
        {
            print("Waiting");
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(2);

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(3);

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(4);

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(5);
    }

    public IEnumerator Lvl01Dio02()
    {

        OpenTextBox(6);

        textBoxOpen = true;


        while (textBoxOpen)
        {
            print("Waiting");
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(7);

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(8);

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(9);


    }

    public IEnumerator Lvl01Dio03()
    {

        OpenTextBox(10);

        textBoxOpen = true;


        while (textBoxOpen)
        {
            print("Waiting");
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(11);

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(12);

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(inBetweenNumber);
        }

        StopCoroutine(dioCor);

        OpenTextBox(13);


    }

    public void Lvl01Dio01FUNC()
    {
        StopAllCoroutines();
        StartCoroutine(Lvl01Dio01());
    }

    public void Lvl01Dio02FUNC()
    {
        StopAllCoroutines();
        StartCoroutine(Lvl01Dio02());
    }
    public void Lvl01Dio03FUNC()
    {
        StopAllCoroutines();
        StartCoroutine(Lvl01Dio03());
    }


    /*
    public void DebugOne()
    {
        OpenTextBox(1);
    }

    public void DebugTwo()
    {
        OpenTextBox(2);
    }

    public IEnumerator PleaseShowUp()
    {

        OpenTextBox(1);

        print("FirstPart");

        while (textBoxOpen)
        {
            yield return new WaitForSeconds(0.07f);
            print("SecondPart");
        }

        OpenTextBox(2);

    }

    public void Debug3()
    {

        OpenTextBox(1);

        print("FirstPart");

        while (textBoxOpen)
        {
            print("SecondPart");
        }

        OpenTextBox(2);

    }

    public void DebugOneTwo()
    {
        StartCoroutine(PleaseShowUp());
    }

    */
}

