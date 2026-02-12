
using UnityEngine;

using UnityEngine.UI;
using System.Collections;


public class SpellCasting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera cam;
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 10f;
   

    public GameObject GameManager;
    public bool IsGrounded = true;

    // Jump Variables
    public CharacterController controller;
    public float jumpHeight = 6.0f;
    public float gravity = -9.81f;
    private Vector3 velocity;


    public bool HealthPagePickedUp = false;
    public bool EnhancementPagePickedUp = false;
    public bool LightningPagePickedUp = false;
    public bool GhostPagePickedUp = false;


    public Vector3 destination;
    public int health, mana = 100;
    public float stamina = 100;
    public Slider healthBar, staminaBar, manaBar;

    private Rigidbody rb;

    public float sprintDepletionRate;
    public float staminaRegenRate;

    public bool EnhancementActive = false;
    public bool manaIncBool;
    public bool canMove = true;
    public bool GhostActive = false;
    //audiosource and sound effects
    public AudioSource SpellCastingProducer;
    public AudioClip[] spellSoundEffects = new AudioClip[7]; //  0 = "Fireball", 1 = "Whirlwind", 2 = "Shield", 3 = "Healing", 4 = "Lightning Cloud", 5 = "Ghost", 6 = "Enhancement"

    public int TargetCount = 0;
    //AFTER DESTROYING ALL TARGETS PLAY DIALOGUE
    public int FirstTimeShield = 2;
    // AFTER COMPLETED SHIELD FOR FIRST TIME PLAY DIALOGUE

    public GameObject ActualShield;
    public GameObject LightningCloud;
    public GameObject EnhancedLightningCloud;

    //dialougetriggers
    public int Lvl2DioInt = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ManaIncrement(0.5f));
        ActualShield.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetCount == 10)
        {
            TargetCount += 1;

        }

        if(FirstTimeShield == -1)
        {
            FirstTimeShield -=0;
        }
        
            

        if (Input.GetMouseButtonDown(0) && GameManager.GetComponent<SpellcastInputs>().CurrentValue <= mana && GameManager.GetComponent<SpellcastInputs>().SpellHeld == true)
        {
            //plays the casting sound effect for each spell
            PlayCastingSound();

            switch (GameManager.GetComponent<SpellcastInputs>().CurrentSpell)
            {
                case "Fireball":

                    ShootProjectile(firePoint);
                    mana -= 10;
                    manaIncBool = true;
                    UpdateData();
                    Debug.Log(mana);
                    break;
                case "Whirlwind":
                    if (EnhancementActive)
                    {
                        jumpHeight = 12f;
                        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                        Debug.Log("Jumped");
                        mana -= 30;
                        manaIncBool = true;
                        UpdateData();
                        Debug.Log(mana);
                        EnhancementActive = false;
                        
                        break;
                    }

                    else
                    {
                        jumpHeight = 6f;
                        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

                        Debug.Log("Jumped");
                        mana -= 30;
                        manaIncBool = true;
                        UpdateData();
                        Debug.Log(mana);
                        break;
                    }
                       

                case "Shield":
                    if (EnhancementActive)
                    {
                        ActualShield.GetComponent<ShieldHealth>().HealthShield = 200;
                        EnhancementActive = false;
                    }
                    ActualShield.SetActive(true);
                    FirstTimeShield--;

                    break;

                case "Healing":
                    if (health < 100)
                    {
                        if (EnhancementActive)
                        {
                            health += 60;
                            mana -= 30;
                            manaIncBool = true;
                            UpdateData();
                            EnhancementActive = false;

                            if (health > 100)
                            {
                                health = 100;
                            }
                            break;
                        }

                        else
                        {
                            if (EnhancementActive)
                            {
                                health += 60;
                                mana -= 30;
                                manaIncBool = true;
                                UpdateData();
                                EnhancementActive = false;
                            }
                            else 
                            {
                                health += 30;
                                mana -= 30;
                                manaIncBool = true;
                                UpdateData();
                            }
                          
                            if (health > 100)
                            {
                                health = 100;
                            }
                            break;
                        }
                           
                    }
                   
                    if (health > 100)
                    {
                        health = 100;
                    }
                    break;

                case "Enhancement":

                    EnhancementActive = true;
                    mana -= 30;
                    manaIncBool = true;
                    UpdateData();

                    break;

                case "Lightning Cloud":
                    if (EnhancementActive)
                    {
                        Instantiate(EnhancedLightningCloud, new Vector3(transform.position.x -18.1f, transform.position.y + 19.99f, transform.position.z +15f), Quaternion.identity);
                        mana -= 70;
                        manaIncBool = true;
                        UpdateData();
                       EnhancementActive=false;
                        break;
                    }

                    else
                    {
                        Instantiate(LightningCloud, new Vector3(transform.position.x - 7.55f, transform.position.y + 9.06f, transform.position.z + 6.87f), Quaternion.identity);
                        mana -= 70;
                        manaIncBool = true;
                        UpdateData();
                        
                    }
                        break;

                case "Ghost":
                    GhostActive = true;
                    Invoke("ResetGhost", 10f);
                    break;
            }
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // --- 1. SPRINTING LOGIC (Depletion)
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            // **FIXED LINE:** Depletion is now framerate-independent
            stamina -= sprintDepletionRate * Time.deltaTime;

            UpdateData(); // Assuming this updates your UI/slider
        }
        // --- 2. REGENERATION LOGIC
        else if (stamina < 100f)
        {
            // **FIXED LINE:** Regeneration is now framerate-independent
            stamina += staminaRegenRate * Time.deltaTime;

            // Clamp the stamina to make sure it doesn't go over 100
            stamina = Mathf.Min(stamina, 100f);

            UpdateData();
        }
    }

    void ShootProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * projectileSpeed;
        Destroy(projectileObj, 5f);
    }
    public void UpdateData()
    {
        healthBar.value = health;
        staminaBar.value = stamina;
        manaBar.value = mana;
    }

    private void PlayCastingSound()
    {
        switch (GameManager.GetComponent<SpellcastInputs>().CurrentSpell)
        {
            case "Fireball":
                
                break;
            case "Healing":
                SpellCastingProducer.clip = spellSoundEffects[3];
                SpellCastingProducer.Play();
                break;
            case "Whirlwind":
                SpellCastingProducer.clip = spellSoundEffects[1];
                SpellCastingProducer.Play();
                break;
            case "Enhancement":
                SpellCastingProducer.clip = spellSoundEffects[6];
                SpellCastingProducer.Play();
                break;

            case "Shield":
                SpellCastingProducer.clip = spellSoundEffects[2];
                SpellCastingProducer.Play();

                break;

            case "Lightning Cloud":
                SpellCastingProducer.clip = spellSoundEffects[4];
                SpellCastingProducer.Play();

                break;

            case "Ghost":
                SpellCastingProducer.clip = spellSoundEffects[5];
                SpellCastingProducer.Play();
                break;


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }

        else
        {
            IsGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                if (!GhostActive)
                {
                    health -= 10;
                    canMove = false;
                    UpdateData();
                    Invoke("AllowEnemyMovement", 3f);
                }
               else
                {
                    canMove = false;
                    Invoke("AllowEnemyMovement", 3f);
                }
                    break;
            case "FireballEnemy":
                break;

            case "HealingSpellPickup":
                Lvl2DioInt = 2;
                HealthPagePickedUp = true;
                Destroy(other.gameObject);
                break;

            case "EnhancementSpellPickup":
                Lvl2DioInt = 4;
                EnhancementPagePickedUp = true;
                Destroy(other.gameObject);
                break;

            case "LightningSpellPickup":
                LightningPagePickedUp = true;
                Destroy(other.gameObject);
                break;

            case "GhostSpellPickup":
                GhostPagePickedUp = true;
                Destroy(other.gameObject);
                break;

            case "DialogueTrigger1":
                Lvl2DioInt = 1;
                Destroy(other.gameObject);
                break;
            case "DialogueTrigger2":
                Lvl2DioInt = 3;
                Destroy(other.gameObject);
                break;
            case "DialogueTrigger3":
                Lvl2DioInt = 5;
                Destroy(other.gameObject);
                break;
            case "Water":
                health = 0;
                UpdateData();
                break;
        }
    }
    void AllowEnemyMovement()
    {
        canMove = true;
    }
    public IEnumerator ManaIncrement(float deltaTime)
    {
        Debug.Log("Increment Started");
        
        while(true)
        {
            yield return new WaitForSeconds(deltaTime);

            if (mana >= 100)
            {
                mana = 100;
                manaIncBool = false;
            }

            else
            {
                mana += 2;
                UpdateData();
            }


        }
        
    }

    void ResetGhost()
    {
        GhostActive = false;
    }

}
