using UnityEngine;

public class ShieldHealth : MonoBehaviour
{

    public int HealthShield = 100;
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireballEnemy")
        {
            HealthShield -= 35;
            
            if (HealthShield <= 0)
            {
                Player.GetComponent<SpellCasting>().FirstTimeShield--;
                Player.GetComponent<SpellCasting>().ActualShield.SetActive(false);
                HealthShield = 100;
            }
        }
    }
}
