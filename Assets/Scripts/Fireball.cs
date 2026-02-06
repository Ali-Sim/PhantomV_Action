using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    private bool collided;
    public GameObject fireBallSound;
    public GameObject Player;
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

        else if (other.gameObject.tag != "Player" && other.gameObject.tag != "Fireball" && other.gameObject.tag != "Tree" && other.gameObject.tag != "Hitbox" && other.gameObject.tag != "Crossbow" && other.gameObject.tag != "DialogueTrigger1" && other.gameObject.tag != "DialogueTrigger2" && other.gameObject.tag != "DialogueTrigger3" && !collided)
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            collided = true;
            Destroy(fbSound, 3f);
            Destroy(gameObject);
            //print("other");
        }


        if (other.gameObject.tag == "EndBoulder")
        {
            GameObject fbSound = Instantiate(fireBallSound, transform.position, Quaternion.identity);
            Destroy(fbSound, 3f);
            if (Player.GetComponent<SpellCasting>().EnhancementActive)
            {
                SceneManager.LoadScene("OutroLevelTwo");
                Destroy(other.gameObject);
                Player.GetComponent<SpellCasting>().EnhancementActive = false;

            }
            
            //Destroy(other.gameObject);
            //print("Target");
        }
    }

    private void Start()
    {
        Player = GameObject.Find("PlayerMain");
    }
}
