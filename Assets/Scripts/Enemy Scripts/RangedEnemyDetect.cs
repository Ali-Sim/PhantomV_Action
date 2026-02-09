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
    public bool canMove = false;
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
                    ShootProjectile(firePoint);
                    canShoot = false;
                    canMove = true;
                    Invoke("AllowEnemyShooting", 3f);
                    Invoke("DisallowEnemymovement", 1f);
                }
                break;
        }
    }
    void AllowEnemyShooting()
    {
        canShoot = true;
    }
    void DisallowEnemymovement()
    {
        canMove = false;
    }
    void ShootProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(fireBall, firePoint.position, Quaternion.identity) as GameObject;
        Vector3 direction = (player.transform.position - firePoint.position).normalized;
        projectileObj.GetComponent<Rigidbody>().linearVelocity = direction * projectileSpeed;
        Destroy(projectileObj, 5f);
    }
}
