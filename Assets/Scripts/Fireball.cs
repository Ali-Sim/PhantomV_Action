using UnityEngine;

public class Fireball : MonoBehaviour
{
    private bool collided;
    public GameObject fireBallSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            Destroy(fbSound, 3f);
            Destroy(gameObject);
            //Destroy(other.gameObject);
            //print("Target");
        }

        else if (other.gameObject.tag != "Player" && other.gameObject.tag != "Fireball" && other.gameObject.tag != "Tree" && other.gameObject.tag != "Hitbox" && other.gameObject.tag != "Crossbow" && !collided)
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            collided = true;
            Destroy(fbSound, 3f);
            Destroy(gameObject);
            //print("other");
        }
    }
}
