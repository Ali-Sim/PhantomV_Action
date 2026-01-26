using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                if (player.GetComponent<SpellCasting>().canMove) { enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, 5f * Time.deltaTime); }
                else { enemy.transform.position = enemy.transform.position; }
                    break;
        }
    }
}
