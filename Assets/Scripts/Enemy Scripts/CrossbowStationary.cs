using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;

public class CrossbowStationary : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject fireBall;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public bool canShoot, canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
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
                    Invoke("AllowEnemyShooting", 3f);
                }
                
                break;
        }
    }
    void AllowEnemyShooting()
    {
        canShoot = true;
    }
    void ShootProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(fireBall, firePoint.position, Quaternion.identity) as GameObject;
        Vector3 direction = (player.transform.position - firePoint.position).normalized;
        projectileObj.GetComponent<Rigidbody>().linearVelocity = direction * projectileSpeed;
        Destroy(projectileObj, 5f);
    }
}
