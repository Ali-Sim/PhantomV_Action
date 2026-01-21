using UnityEngine;

public class CSVText : MonoBehaviour
{
    //CSV 
    public TextAsset csvDialogue;
    public string[,] grid;

    //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = getCSVGrid(csvDialogue.text);

        //How to call items in the CSV - grid[x, y] where x and y are numbers starting from 0 (A1 on the excel sheet would be 0,0 and A2 on the excell sheet would be 0,1)
        Debug.Log(grid[0, 1]);
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
}
