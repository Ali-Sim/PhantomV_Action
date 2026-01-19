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

    public Vector3 destination;
    public int health, mana, stamina = 100;
    public Slider healthBar, staminaBar, manaBar;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mana > 0 && GameManager.GetComponent<SpellcastInputs>().SpellHeld == true)
        {
            ShootProjectile(firePoint);
            mana -= 10;
            UpdateData();
            Debug.Log(mana);
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
}
