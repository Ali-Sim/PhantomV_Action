using Unity.VisualScripting;
using UnityEngine;

public class CrossbowEnemy : MonoBehaviour
{
    public GameObject hitbox, player;
    public int lives = 100;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fireball":
                lives -= 35;
                if (lives <= 0)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "LightningCloud":
                lives -= 100;
                Invoke("DestroyEnemy", 1f);
                break;
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

