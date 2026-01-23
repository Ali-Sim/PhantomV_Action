using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int lives = 3;
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

