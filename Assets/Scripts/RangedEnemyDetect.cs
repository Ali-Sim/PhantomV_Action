using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;

public class RangedEnemyDetect : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject fireBall;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public bool canShoot = true;
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
                else { }
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
        projectileObj.GetComponent<Rigidbody>().linearVelocity = Vector3.MoveTowards(firePoint.position, player.transform.position, projectileSpeed * Time.deltaTime); //Fix this bum
        Destroy(projectileObj, 5f);
    }
}
