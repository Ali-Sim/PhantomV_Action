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
    private int KeyLightUp;
    //Added fireBall GObj to the code -Marcus
    public GameObject fireBall;
    

    public GameObject[] BookImages = new GameObject[7];
    public GameObject[] KeyImages = new GameObject[4];
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
            ResetColor();
            PlayerInput = 'q';
            KeyLightUp = 3;
            CheckSpell();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetColor();
            PlayerInput = 'r';
            KeyLightUp = 0;
            CheckSpell();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetColor();
            PlayerInput = 'e';
            KeyLightUp = 1;
            CheckSpell();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ResetColor();
            PlayerInput = 'f';
            KeyLightUp = 2;
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
            KeyImages[KeyLightUp].GetComponent<Image>().color = Color.green;
            Invoke("ResetColor", .5f);

            if (CurrentCombo == "")
            {
                Debug.Log("You casted: " + Spells[PageNum]);
                SpellHeld = true;
            }
            //Makes it so the fireball appears in the players hand
            //I didn't code any of the logic behind it but I just thought it would be cool-Marcus
            if (SpellHeld)
            {
                fireBall.SetActive(true);
            }
            else { fireBall.SetActive(false); }
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

    void ResetColor()
    {
        KeyImages[KeyLightUp].GetComponent<Image>().color = Color.white;
    }
}
