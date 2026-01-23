using UnityEngine;

public class FireballEnemy : MonoBehaviour
{
    private bool collided;
    public GameObject fireBallSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            Destroy(fbSound, 3f);
            Destroy(gameObject);
        }

        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Hitbox" && !collided)
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            collided = true;
            Destroy(fbSound, 3f);
            Destroy(gameObject);
        }
    }
}
