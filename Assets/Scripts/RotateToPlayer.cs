using UnityEngine;



public class RotateToPlayer : MonoBehaviour
{
    public Transform playerTransform; // Assign the player's Transform in the Inspector
    public float rotationSpeed = 5f; // Adjust the rotation speed

    private bool playerInTrigger = false;
    public GameObject Player;


    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        Player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player GameObject has the "Player" tag
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    void Update()
    {
        if (playerInTrigger && playerTransform != null)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0; // Keep the rotation on the Y-axis (horizontal)

            // Create a target rotation looking at the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}