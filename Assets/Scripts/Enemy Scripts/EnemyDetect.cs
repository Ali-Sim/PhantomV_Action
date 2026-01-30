using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyDetect : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject[] enemyStance = new GameObject[4];
    public float animationSpeed = 1f; // Time between stance swaps

    private Coroutine stanceRoutine;
    private bool isMoving = false;
    private SpellCasting playerSpellScript;

    public GameObject EnemyAttack1, EnemyAttack2;

    public bool CancelAnimation = false;
    void Start()
    {
        // calling the script for better performance
        playerSpellScript = player.GetComponent<SpellCasting>();

        // Ensures only the first stance is active at start
        SetStance(0);


        EnemyAttack1.SetActive(false);
        EnemyAttack2.SetActive(false);
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelAnimation = true;

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
        enemyStance[0].SetActive(false);
        EnemyAttack1.SetActive(true);
        Invoke("EnemySecondAttack", 1.5f);
        Invoke("EndEnemyAttack", 3f);
        
        
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

    void EnemySecondAttack()
    {
        if (CancelAnimation)
        {
            EnemyAttack1.SetActive(false);
            EnemyAttack2.SetActive(false);
            enemyStance[0].SetActive(true);
            CancelAnimation = false;
        }
        else
        {
            EnemyAttack1.SetActive(false);
            EnemyAttack2.SetActive(true);
        }
            
    }

    void EndEnemyAttack()
    {
        if (CancelAnimation)
        {
            EnemyAttack1.SetActive(false);
            EnemyAttack2.SetActive(false);
            enemyStance[0].SetActive(true);
            CancelAnimation = false;
        }

        else
        {
            EnemyAttack2.SetActive(false);
            enemyStance[0].SetActive(true);
        }

            
    }
}