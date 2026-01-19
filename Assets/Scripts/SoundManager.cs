using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public GameObject footstepProducer;
    public AudioSource stepsSource;
    public AudioClip footstepClip;
    public int[] keysPressed = new int[4] {0,0,0,0};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        footstepProducer.SetActive(false);
        stepsSource.clip = footstepClip;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        if ((keysPressed[0] == 1) || (keysPressed[1] == 1) || (keysPressed[2] == 1) || (keysPressed[3] == 1))
        {
            footstepProducer.SetActive (true);

        }
        else
        {
            footstepProducer.SetActive(false) ;
        }
    }

    void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(keysPressed[0].ToString() + keysPressed[1].ToString() + keysPressed[2].ToString() + keysPressed[3].ToString());
        }

        //If A Key Is Pressed Down
        if (Input.GetKeyDown(KeyCode.W))
        {
            keysPressed[0] = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            keysPressed[1] = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            keysPressed[2] = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            keysPressed[3] = 1;
        }

        //If A Key Is Released
        if (Input.GetKeyUp(KeyCode.W))
        {
            keysPressed[0] = 0;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            keysPressed[1] = 0;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            keysPressed[2] = 0;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            keysPressed[3] = 0;
        }
    }
}


