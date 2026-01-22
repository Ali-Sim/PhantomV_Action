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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                if (player.GetComponent<SpellCasting>().canMove == true) { enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, 5f * Time.deltaTime); }
                else { enemy.transform.position = enemy.transform.position; }
                    break;
        }
    }
}
