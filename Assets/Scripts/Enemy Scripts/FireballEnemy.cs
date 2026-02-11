using UnityEngine;

public class FireballEnemy : MonoBehaviour
{
    private bool collided;
    public GameObject fireBallSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            if (other.GetComponent<SpellCasting>().GhostActive == false)
            {
                other.GetComponent<SpellCasting>().health -= 20;
                other.GetComponent<SpellCasting>().UpdateData();
            }
           
            Destroy(fbSound, 3f);
            Destroy(gameObject);
            //Debug.Log(other.gameObject.tag);
        }

        else if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Hitbox" && other.gameObject.tag != "Tree" && other.gameObject.tag != "Crossbow" && !collided)
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            collided = true;
            Destroy(fbSound, 3f);
            Destroy(gameObject);
            //Debug.Log(other.gameObject.tag + "Other");

        }
    }
}
