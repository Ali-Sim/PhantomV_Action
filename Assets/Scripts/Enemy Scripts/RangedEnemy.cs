using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public int lives = 5;
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Fireball":
                lives--;
                if (lives == 0)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}

