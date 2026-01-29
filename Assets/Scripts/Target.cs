using Mono.Cecil;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject brokenTarget;
    public GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("PlayerMain");
    }
    private void OnTriggerEnter(Collider other)
    {
        

        switch (other.gameObject.tag)
        {
            case "Fireball":
                Vector3 targetPos = gameObject.transform.position;
                Player.GetComponent<SpellCasting>().TargetCount++;
                Player.GetComponent<SpellCasting>().TargetCount += 1;
                gameObject.SetActive(false);
                brokenTarget.SetActive(true);
                Invoke("RegenTarget", 3f);
                break;
        }
    }
    void RegenTarget() 
    { gameObject.SetActive(true); brokenTarget.SetActive(false); }
}
