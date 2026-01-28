using Mono.Cecil;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject brokenTarget;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fireball":
                Vector3 targetPos = gameObject.transform.position;
                gameObject.SetActive(false);
                brokenTarget.SetActive(true);
                Invoke("RegenTarget", 3f);
                break;
        }
    }
    void RegenTarget() 
    { gameObject.SetActive(true); brokenTarget.SetActive(false); }
}
