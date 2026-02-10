using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.Rendering;

public class RangedEnemyDetect : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject fireBall;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public bool canShoot = true;
    public bool canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                if (canShoot)
                {
                    canMove = false;
                    Invoke("ShootProjectileDelay", 2f);
                    canShoot = false;
                    Invoke("AllowMovement", 5f);
                    Invoke("AllowEnemyShooting", 8f);
                   
                }
                break;
        }
    }
    void AllowEnemyShooting()
    {
        canShoot = true;
    }
    
    void AllowMovement()
    {
        canMove = true;
    }

    void ShootProjectileDelay()
    {
        ShootProjectile(firePoint);
        
    }


    void ShootProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(fireBall, firePoint.position, Quaternion.identity) as GameObject;
        Vector3 direction = (player.transform.position - firePoint.position).normalized;
        projectileObj.GetComponent<Rigidbody>().linearVelocity = direction * projectileSpeed;
        Destroy(projectileObj, 5f);
    }
}
