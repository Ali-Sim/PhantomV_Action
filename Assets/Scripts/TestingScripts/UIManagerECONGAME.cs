/*using System.Collections;

using TMPro;

using UnityEngine;

using UnityEngine.SceneManagement;


public class UIManagerECONGAME : MonoBehaviour
{
    public TMP_Text dialougeTxt;
    public TMP_Text nameTxt;
    public TMP_Text buttonTxt;

    public float dialogueType = 0.025f;

    public int currentPage = 0;

    string currentTextScript;

    bool imageJump;

    public GameObject characterMiddle;
    public GameObject characterRight;
    public GameObject characterLeft;

    public AudioClip[] LiaBilityVoiceLines;
    public AudioClip[] MrGuyLiaBility_VoiceLines;
    public AudioClip[] NohomeMchouseless_VoiceLines;
    public AudioClip[] Accountant_VoiceLines;
    public AudioClip[] MilesPremium_VoiceLines;
    public AudioClip[] MrGuyAccountant_VoiceLines;
    public AudioClip[] MrGuyNohomeMchouseless_VoiceLines;
    public AudioClip[] MrGuyMilesPremium_VoiceLines;


    public Animator animatorCharacterOne;

    public Animator currentAnimator;

    public GameObject backgroundImage;

    public bool finishedPlaying = true;

    public bool changeScene = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPage = 0;
        dialougeTxt.text = "";

        currentPage += 1;
        DialougeClick();

        currentAnimator = animatorCharacterOne;

     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
    public void DialougeClick()
    {
        switch (currentPage)
        {

            case 1:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[0];
                GetComponent<AudioSource>().Play();

                break;
            case 2:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[0];
                GetComponent<AudioSource>().Play();
                break;
            case 3:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 4:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 5:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[2];
                GetComponent<AudioSource>().Play();
                break;
            case 6:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[2];
                GetComponent<AudioSource>().Play();
                break;
            case 7:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[3];
                GetComponent<AudioSource>().Play();
                break;
            case 8:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[3];
                GetComponent<AudioSource>().Play();
                break;
            case 9:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[4];
                GetComponent<AudioSource>().Play();
                break;
            case 10:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[4];
                GetComponent<AudioSource>().Play();
                break;
            case 11:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[5];
                GetComponent<AudioSource>().Play();
                break;
            case 12:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[5];
                GetComponent<AudioSource>().Play();
                break;
            case 13:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 14:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 15:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 16:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 17:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[8];
                GetComponent<AudioSource>().Play();
                break;
            case 18:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyAccountant_VoiceLines[8];
                GetComponent<AudioSource>().Play();
                break;

            // Begin Conversation with Nohome McHousless
            case 19:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = Accountant_VoiceLines[9];
                GetComponent<AudioSource>().Play();
                changeScene = true;
                break;


            case 20:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[0];
                GetComponent<AudioSource>().Play();
                break;
            case 21:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[0];
                GetComponent<AudioSource>().Play();
                break;
            case 22:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 23:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 24:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[2];
                GetComponent<AudioSource>().Play();

                break;
            case 25:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[2];
                GetComponent<AudioSource>().Play();

                break;
            case 26:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[3];
                GetComponent<AudioSource>().Play();

                break;
            case 27:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[3];
                GetComponent<AudioSource>().Play();

                break;
            case 28:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[4];
                GetComponent<AudioSource>().Play();
                break;
            case 29:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[4];
                GetComponent<AudioSource>().Play();

                break;
            case 30:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[5];
                GetComponent<AudioSource>().Play();
                break;
            case 31:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[5];
                GetComponent<AudioSource>().Play();

                break;
            case 32:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 33:
                PlayDio();

                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 34:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 35:
                PlayDio();

                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 36:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[8];
                GetComponent<AudioSource>().Play();
                break;
            case 37:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[8];
                GetComponent<AudioSource>().Play();

                break;
            case 38:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[9];
                GetComponent<AudioSource>().Play();
                break;
            case 39:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[9];
                GetComponent<AudioSource>().Play();
                break;
            case 40:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[10];
                GetComponent<AudioSource>().Play();
                break;
            case 41:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[10];
                GetComponent<AudioSource>().Play();
                break;
            case 42:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[11];
                GetComponent<AudioSource>().Play();
                break;
            case 43:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[11];
                GetComponent<AudioSource>().Play();
                break;
            case 44:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[12];
                GetComponent<AudioSource>().Play();
                break;
            case 45:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[12];
                GetComponent<AudioSource>().Play();
                break;
            case 46:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[13];
                GetComponent<AudioSource>().Play();
                break;
            case 47:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[13];
                GetComponent<AudioSource>().Play();
                break;
            case 48:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[14];
                GetComponent<AudioSource>().Play();
                break;
            case 49:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyNohomeMchouseless_VoiceLines[14];
                GetComponent<AudioSource>().Play();
                break;

            // End conversation with Nohome Mchouseless
            // Begin conversation with Lia Bility

            case 50:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = NohomeMchouseless_VoiceLines[15];
                GetComponent<AudioSource>().Play();
                SoundManager.Instance.characterMetCount += 1;
                changeScene = true;
                break;
            case 51:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[0];
                GetComponent<AudioSource>().Play();
                break;
            case 52:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[0];
                GetComponent<AudioSource>().Play();
                break;
            case 53:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 54:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 55:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[2];
                GetComponent<AudioSource>().Play();
                break;
            case 56:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[2];
                GetComponent<AudioSource>().Play();
                break;
            case 57:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[3];
                GetComponent<AudioSource>().Play();
                break;
            case 58:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[3];
                GetComponent<AudioSource>().Play();
                break;
            case 59:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[4];
                GetComponent<AudioSource>().Play();
                break;
            case 60:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[4];
                GetComponent<AudioSource>().Play();
                break;
            case 61:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[5];
                GetComponent<AudioSource>().Play();
                break;
            case 62:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[5];
                GetComponent<AudioSource>().Play();
                break;
            case 63:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 64:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 65:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 66:
                PlayDio();
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 67:
                PlayDio();
                GetComponent<AudioSource>().Stop();

                break;
            case 68:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[8];
                GetComponent<AudioSource>().Play();

                break;
            case 69:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[8];
                GetComponent<AudioSource>().Play();
                break;
            case 70:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[9];
                GetComponent<AudioSource>().Play();

                break;
            case 71:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[9];
                GetComponent<AudioSource>().Play();
                break;
            case 72:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[10];
                GetComponent<AudioSource>().Play();
                break;
            case 73:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[10];
                GetComponent<AudioSource>().Play();
                break;
            case 74:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[11];
                GetComponent<AudioSource>().Play();

                break;
            case 75:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[11];
                GetComponent<AudioSource>().Play();
                break;
            case 76:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[12];
                GetComponent<AudioSource>().Play();
                break;
            case 77:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[12];
                GetComponent<AudioSource>().Play();
                break;
            case 78:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[13];
                GetComponent<AudioSource>().Play();

                break;
            case 79:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[13];
                GetComponent<AudioSource>().Play();
                break;
            case 80:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyLiaBility_VoiceLines[14];
                GetComponent<AudioSource>().Play();

                break;

            //End of conversation with Lia Bility
            //Begin Conversation with Miles Premium 

            case 81:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = LiaBilityVoiceLines[14];
                GetComponent<AudioSource>().Play();
                SoundManager.Instance.characterMetCount += 1;
                changeScene = true;
                break;


            case 82:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[0];
                GetComponent<AudioSource>().Play();
                break;
            case 83:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[0];
                GetComponent<AudioSource>().Play();
                break;
            case 84:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 85:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[1];
                GetComponent<AudioSource>().Play();
                break;
            case 86:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[2];
                GetComponent<AudioSource>().Play();
                break;
            case 87:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[2];
                GetComponent<AudioSource>().Play();
                break;
            case 88:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[3];
                GetComponent<AudioSource>().Play();
                break;
            case 89:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[3];
                GetComponent<AudioSource>().Play();
                break;
            case 90:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[4];
                GetComponent<AudioSource>().Play();
                break;
            case 91:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[4];
                GetComponent<AudioSource>().Play();
                break;
            case 92:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[5];
                GetComponent<AudioSource>().Play();
                break;
            case 93:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[5];
                GetComponent<AudioSource>().Play();
                break;
            case 94:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 95:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[6];
                GetComponent<AudioSource>().Play();
                break;
            case 96:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 97:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[7];
                GetComponent<AudioSource>().Play();
                break;
            case 98:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[8];
                GetComponent<AudioSource>().Play();
                break;
            case 99:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[8];
                GetComponent<AudioSource>().Play();
                break;
            case 100:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[9];
                GetComponent<AudioSource>().Play();
                break;
            case 101:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[9];
                GetComponent<AudioSource>().Play();
                break;
            case 102:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[10];
                GetComponent<AudioSource>().Play();
                break;
            case 103:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[11];
                GetComponent<AudioSource>().Play();
                break;
            case 104:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[10];
                GetComponent<AudioSource>().Play();
                break;
            case 105:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[12];
                GetComponent<AudioSource>().Play();
                break;
            case 106:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[11];
                GetComponent<AudioSource>().Play();
                break;
            case 107:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[13];
                GetComponent<AudioSource>().Play();
                break;
            case 108:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[12];
                GetComponent<AudioSource>().Play();
                break;
            case 109:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[14];
                GetComponent<AudioSource>().Play();
                break;
            case 110:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MrGuyMilesPremium_VoiceLines[13];
                GetComponent<AudioSource>().Play();
                break;
            case 111:
                PlayDio();
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MilesPremium_VoiceLines[15];
                GetComponent<AudioSource>().Play();
                SoundManager.Instance.characterMetCount += 1;
                changeScene = true;
                break;



        }


    }

    public void ClickForwards()
    {
        
        if (finishedPlaying)
        {
            if (changeScene)
            {
                SceneManager.LoadScene("CharacterSelectionScreen");
            }

            else
            {
                currentPage += 1;
                DialougeClick();
            }
            
        }
        else
        {
            PlayDio();
        }
        
    }

    public void ClickBacks()
    {
        if ((currentPage > 1) && (currentPage > SoundManager.Instance.startingPageIndex + 1))
        {
            currentPage -= 1;
            
            DialougeClick();

            
        }
        
    }

    public IEnumerator Dialogue(string message)
    {
        //pick message to show
        dialougeTxt.text = "";
        string newDialogue = message;

        finishedPlaying = false;


        //type out message
        foreach (char c in newDialogue)
        {
            dialougeTxt.text += c;
            yield return new WaitForSeconds(dialogueType);
        }

        finishedPlaying = true;


    }

    void PlayDio()
    {
        if (finishedPlaying)
        {
            StopAllCoroutines();
            dialougeHolder.DialogueOutput(currentPage - 1);
            currentTextScript = dialougeHolder.currentText;
            nameTxt.text = dialougeHolder.currentSpeaker;
            StartCoroutine(Dialogue(currentTextScript));

            
            animatorCharacterOne.SetTrigger("JumpTrigger");
        }

        else
        {
            finishedPlaying = true;
            StopAllCoroutines();
            dialougeHolder.DialogueOutput(currentPage - 1);
            currentTextScript = dialougeHolder.currentText;
            nameTxt.text = dialougeHolder.currentSpeaker;
            dialougeTxt.text = currentTextScript;
        }


        dialougeHolder.ChangeCharacter();
    }

 
}
*/