using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public GameObject player;
    public bool followPlayer = false;
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            followPlayer = true;
            EnemyFollow();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            followPlayer = true;
            EnemyFollow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            followPlayer = false;
            EnemyFollow();
        }
    }

    void EnemyFollow()
    {
        if (followPlayer)
        {
            Vector3 playerPos = player.transform.position;
            enemy.GetComponent<EnemyScript>().transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * 1.5f);
        }

        else if (!followPlayer)
        {
            transform.position = transform.position;
        }
    }
}