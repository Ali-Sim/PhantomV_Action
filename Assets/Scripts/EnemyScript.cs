using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject EnemyDetectObject;
    public float startingValue;

    public GameObject ragdoll;

    public Vector3 endPos;

    public int PlayerCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingValue = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = startingValue;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackField"))
        {
            PlayerCounter += 1;
            transform.position = transform.position;
            Debug.Log("AttackHit");

            endPos = transform.position;

            if (PlayerCounter == 1)
            {
                Invoke("EnemyRag", 3.79f);
            }

            Invoke("EnemyDead", 3.8f);
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }

    void EnemyRag()
    {
        GameObject rag = Instantiate(ragdoll, endPos, Quaternion.identity);
    }
}