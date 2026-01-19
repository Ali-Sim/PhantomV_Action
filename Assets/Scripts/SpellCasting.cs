using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.UI;

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



    public Vector3 destination;
    public int health, mana = 100;
    public float stamina = 100;
    public Slider healthBar, staminaBar, manaBar;

    private Rigidbody rb;

    public float sprintDepletionRate;
    public float staminaRegenRate;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.GetComponent<SpellcastInputs>().CurrentValue <= mana && GameManager.GetComponent<SpellcastInputs>().SpellHeld == true)
        {
            switch (GameManager.GetComponent<SpellcastInputs>().CurrentSpell)
            {
                case "Fireball":

                    ShootProjectile(firePoint);
                    mana -= 10;
                    UpdateData();
                    Debug.Log(mana);
                    break;
                case "Whirlwind":

                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    
                    Debug.Log("Jumped");
                    mana -= 30;
                    UpdateData();
                    Debug.Log(mana);
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
        //Vector3 firePointPos = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
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
}
