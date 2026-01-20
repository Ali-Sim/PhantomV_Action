using UnityEngine;
using System.Windows.Input;
using NUnit.Framework;
using UnityEngine.UI;
using System.Dynamic;

public class SpellcastInputs : MonoBehaviour
{
    // Page of the book that the player is on
    public int PageNum = 0;

    // Arrays that hold the Spell names and their combos required to cast them
    public string[] combos = new string[] { "qe", "frq", "qreeq", "efr", "fqereq", "erfqee", "rrr" };
    public string[] Spells = new string[] { "Fireball", "Whirlwind", "Shield", "Healing", "Lightning Cloud", "Ghost", "Enhancement" };
    public int[] Values = new int[] { 10, 30, 50, 30, 70, 70, 30 };


    public char PlayerInput;
    public string CurrentCombo = "";
    public string CurrentSpell = "";
    public int CurrentValue = 10;
    public bool SpellHeld = false;
    private int KeyLightUp;



    //Added fireBall GObj to the code -Marcus
    public GameObject fireBall, whirlWind;

    // Hold the UI Images for the InputKeys and the Book Pages
    public GameObject[] BookImages = new GameObject[7];
    public GameObject[] KeyImages = new GameObject[4];

    //audiosources and clips for the sound effects
    public AudioSource SpellInputProducer;
    public AudioSource SpellActivationProducer;

    public AudioClip[] spellSoundEffects = new AudioClip[7]; //  0 = "Fireball", 1 = "Whirlwind", 2 = "Shield", 3 = "Healing", 4 = "Lightning Cloud", 5 = "Ghost", 6 = "Enhancement"
    public AudioClip[] bellSoundEffects = new AudioClip[2]; // 0 = Good Bell, 1 = Bad Bell


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Resets the page number and images to always start on the fireball page
        CurrentCombo = combos[PageNum];
        ResetImages();
        BookImages[PageNum].SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {

        // If the player clicks the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Increments the page by one
            PageNum += 1;

            // resets the page number to 0 if PageNum goes beyond the max number of pages
            if (PageNum == 7) { PageNum = 0;}
            Debug.Log(PageNum);

            // Sets the current combination to the corresponding spell on the page
            CurrentCombo = combos[PageNum];
            CurrentValue = Values[PageNum];
            Debug.Log(CurrentCombo);

            //Sets spell held to false if the player flips to a new page
            //SpellHeld = false;

            // Sets the book image to whatever page the player is on
            ResetImages();
            BookImages[PageNum].SetActive(true);
        }

        // If the player presses the Q key
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Resets the color back to white in the event a player presses two buttons in rapid succession
            ResetColor();

            // Sets PlayerInput to the character "q"
            PlayerInput = 'q';

            //Sets the key to be lit up in the event the player pressed the correct key
            KeyLightUp = 3;

            //Checks whether or not the button pressed is the correct button in the order of the spell combination
            CheckSpell();
        }

        // If the player presses the R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Resets the color back to white in the event a player presses two buttons in rapid succession
            ResetColor();

            // Sets PlayerInput to the character "r"
            PlayerInput = 'r';

            //Sets the key to be lit up in the event the player pressed the correct key
            KeyLightUp = 0;

            //Checks whether or not the button pressed is the correct button in the order of the spell combination
            CheckSpell();
        }

        // If the player presses the E key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Resets the color back to white in the event a player presses two buttons in rapid succession
            ResetColor();

            // Sets PlayerInput to the character "e"
            PlayerInput = 'e';

            //Sets the key to be lit up in the event the player pressed the correct key
            KeyLightUp = 1;

            //Checks whether or not the button pressed is the correct button in the order of the spell combination
            CheckSpell();
        }

        // If the player presses the F key
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Resets the color back to white in the event a player presses two buttons in rapid succession
            ResetColor();

            // Sets PlayerInput to the character "f"
            PlayerInput = 'f';

            //Sets the key to be lit up in the event the player pressed the correct key
            KeyLightUp = 2;

            //Checks whether or not the button pressed is the correct button in the order of the spell combination
            CheckSpell();
        }
    }


    void CheckSpell()
    {
        

        //Creates a variable that holds the first character of the combination (Even after a character has been removed)
        char FirstLetter = CurrentCombo[0];

        //Checks if the players character input (QERF) is equal to the first letter in the combination (Player must enter the character in order)
        if (PlayerInput == FirstLetter)
        {
            //plays first bell sound
            PlayCorrectSound();

            Debug.Log("OG:" + CurrentCombo);

            // If the player entered the correct character, it removes that character from the combination
            CurrentCombo = CurrentCombo.Remove(0,1);

            Debug.Log("After:" + CurrentCombo);

            // Lights up the corresponding letter that the player pressed, and resets it back to white after .5 seconds
            KeyImages[KeyLightUp].GetComponent<Image>().color = Color.green;
            Invoke("ResetColor", .5f);

            if (CurrentCombo == "")
            {
                // If the player completes the combination, it tells the player what spell they casted and sets SpellHeld to true, changes CurrentSpell to the spell that the player is holding
                Debug.Log("You casted: " + Spells[PageNum]);
                CurrentSpell = Spells[PageNum];
                SpellHeld = true;
            }
            //Makes it so the fireball appears in the players hand
            //I didn't code any of the logic behind it but I just thought it would be cool-Marcus
            if (SpellHeld)
            {
                WhatSpell();
            }

            else { fireBall.SetActive(false); whirlWind.SetActive(false); }
        }

        else
        {
            //plays the bad bell sounds for an incoreect answer
            PlayWrongSound();

            // if the player gets a letter wrong, resets the combination back to the original combo and tells the player they got it wrong
            CurrentCombo = combos[PageNum];
            Debug.Log("U got it wrong");
        }
    }

    //Resets all of the book images
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

    // Resets the color of the key that was pressed
    void ResetColor()
    {
        KeyImages[KeyLightUp].GetComponent<Image>().color = Color.white;
    }

    void ResetSpells()
    {
        fireBall.SetActive(false); 
        whirlWind.SetActive(false);
    }

    void WhatSpell()
    {
        //plays the sound for activating a spell
        ActivationSound(); 

        switch (CurrentSpell)
            
        {
            case "Fireball":

                ResetSpells();
                fireBall.SetActive(true);

                break;

            case "Whirlwind":

                ResetSpells();
                whirlWind.SetActive(true);

                break;


        }
    }

    void PlayCorrectSound() //plays a bad bell sound
    {
        SpellInputProducer.clip = bellSoundEffects[0];
        SpellInputProducer.Play();
    }

    void PlayWrongSound() //plays a good bell sound
    {
        SpellInputProducer.clip = bellSoundEffects[1];
        SpellInputProducer.Play();
    }

    void ActivationSound() //plays a sound depending on the spell when they get activated
    {
        switch (CurrentSpell)
        {
            case "Fireball":
                SpellActivationProducer.clip = spellSoundEffects[0];
                SpellActivationProducer.Play();
                break;

            case "Whirlwind":
                SpellActivationProducer.clip = spellSoundEffects[1];
                SpellActivationProducer.Play();
                break;


        }
    }
}
