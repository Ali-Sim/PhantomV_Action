using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyHealth = 100;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Fireball":
                if (Player.GetComponent<SpellCasting>().EnhancementActive)
                {
                    EnemyHealth -= 100;
                    Player.GetComponent<SpellCasting>().EnhancementActive = false;
                }
                else { EnemyHealth -= 50; }

                if (EnemyHealth <= 0)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}

