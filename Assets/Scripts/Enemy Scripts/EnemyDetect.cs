using UnityEngine;
using System.Collections;

public class EnemyDetect : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject[] enemyStance = new GameObject[4];
    public float animationSpeed = 1f; // Time between stance swaps

    private Coroutine stanceRoutine;
    private bool isMoving = false;
    private SpellCasting playerSpellScript;

    void Start()
    {
        // calling the script for better performance
        playerSpellScript = player.GetComponent<SpellCasting>();

        // Ensures only the first stance is active at start
        SetStance(0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerSpellScript.canMove)
            {
                // Movement Logic
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, 5f * Time.deltaTime);

                // Start the loop if we aren't already moving
                if (!isMoving)
                {
                    isMoving = true;
                    stanceRoutine = StartCoroutine(StanceLoop());
                }
            }
            else
            {
                StopMovement();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopMovement();
        }
    }

    private void StopMovement()
    {
        isMoving = false;
        if (stanceRoutine != null)
        {
            StopCoroutine(stanceRoutine);
            stanceRoutine = null;
        }
        SetStance(0); // Return to Idle/Default stance
    }

    IEnumerator StanceLoop()
    {
        int currentIndex = 0;
        while (isMoving)
        {
            SetStance(currentIndex);

            // Increment index and loop back to 0 if we hit the end
            currentIndex = (currentIndex + 1) % enemyStance.Length;

            yield return new WaitForSeconds(animationSpeed);
        }
    }

    void SetStance(int index)
    {
        for (int i = 0; i < enemyStance.Length; i++)
        {
            if (enemyStance[i] != null)
            {
                enemyStance[i].SetActive(i == index);
            }
        }
    }
}