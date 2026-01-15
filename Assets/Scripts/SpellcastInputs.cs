using UnityEngine;
using System.Windows.Input;
using NUnit.Framework;
using UnityEngine.UI;
using System.Dynamic;

public class SpellcastInputs : MonoBehaviour
{

    public int PageNum = 0;
    public string[] combos = new string[] {"qe", "frq", "qreeq", "efr", "fqereq", "erfqee", "rrr" } ;
    public string[] Spells = new string[] { "Fireball", "Whirlwind", "Shield", "Healing", "Lightning Cloud", "Ghost", "Enhancement" };
    public char PlayerInput;
    public string CurrentCombo = "";
    public bool SpellHeld = false;

    public GameObject[] BookImages = new GameObject[7];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentCombo = combos[PageNum];
        ResetImages();
        BookImages[PageNum].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PageNum += 1;
            if (PageNum == 7) { PageNum = 0;}
            Debug.Log(PageNum);
            CurrentCombo = combos[PageNum];
            Debug.Log(CurrentCombo);
            SpellHeld = false;

            ResetImages();
            BookImages[PageNum].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerInput = 'q';
            CheckSpell();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerInput = 'r';
            CheckSpell();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInput = 'e';
            CheckSpell();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerInput = 'f';
            CheckSpell();
        }
    }


    void CheckSpell()
    {
        char FirstLetter = CurrentCombo[0];
        if (PlayerInput == FirstLetter)
        {
            Debug.Log("OG:" + CurrentCombo);
            CurrentCombo = CurrentCombo.Remove(0,1);
            Debug.Log("After:" + CurrentCombo);

            if (CurrentCombo == "")
            {
                Debug.Log("You casted: " + Spells[PageNum]);
                SpellHeld = true;
            }
        }

        else
        {
            CurrentCombo = combos[PageNum];
            Debug.Log("U got it wrong");
        }
    }

    void ResetImages()
    {
        BookImages[0].SetActive(false);
        BookImages[1].SetActive(false);
        BookImages[2].SetActive(false);
        BookImages[3].SetActive(false);
        BookImages[4].SetActive(false);
        BookImages[5].SetActive(false);
        BookImages[6].SetActive(false);
    }
}
