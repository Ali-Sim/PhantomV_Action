using TMPro;
using UnityEngine;
using System.Collections;
using static UnityEditor.Rendering.MaterialUpgrader;

public class DialogueManager : MonoBehaviour
{
    //CSV Finder
    public TextAsset csvDialogue;
    public string[,] grid;

    //Diolouge Box
    public GameObject dialougeBox;
    public TMP_Text dialougeTxt, nameTxt;
    public float dialogueType = 0.025f;

    //DialougeVariables
    public bool canTalk, startedPlaying, currentlyPlaying, donePlaying;
    public bool doneTyping;

    //Indexes
    public int characterID;
    public int currentTextIndex;
    public int lengthOfDialouge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //How to call items in the CSV - grid[x, y] where x and y are numbers starting from 0 (A1 on the excel sheet would be 0,0 and A2 on the excell sheet would be 0,1)
        //How to call certain characters - grid[2 + currentTextIndex, characterID]
        grid = getCSVGrid(csvDialogue.text);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OpenTextBox(int index)
    {

    }

    public void ClickForward()
    {

    }

    public void ClickBackwards()
    {

    }

    public void CloseTextBox()
    {

    }
}
