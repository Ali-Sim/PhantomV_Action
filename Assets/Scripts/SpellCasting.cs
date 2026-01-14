using UnityEngine;
using UnityEngine.Apple;

public class SpellCasting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera cam;
    public GameObject projectile;
    public Transform firePoint;

    private Vector3 destination;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }
    
    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        InstantiateProjectile();
    }

    void InstantiateProjectile()
    {
        Vector3 firePointPos = new Vector3(firePoint.position.x, firePoint.position.y - 5, firePoint.position.z);
        var projectileObj = Instantiate(projectile, firePointPos, Quaternion.identity) as GameObject;
    }
}
