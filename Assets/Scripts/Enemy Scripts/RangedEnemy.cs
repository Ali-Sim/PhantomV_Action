using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject hitbox, player;
    public int lives = 5;
    public void Update()
    {
        if (hitbox.GetComponent<RangedEnemyDetect>().canMove == true)
        {
            Vector3 moveEnemy = Vector3.MoveTowards(transform.position, player.transform.position, 4f * Time.deltaTime);
            transform.position = moveEnemy;
        }
    }
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

