using UnityEngine;

public class Fireball : MonoBehaviour
{
    private bool collided;
    public GameObject fireBallSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }

        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Fireball" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }

        Instantiate(fireBallSound, transform.position, Quaternion.identity);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
