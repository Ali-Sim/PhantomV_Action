using UnityEngine;
using System.Collections;

public class ShieldHealth : MonoBehaviour
{

    public int HealthShield = 100;
    public GameObject Player;
    public GameObject ShieldFULL;
    public GameObject ShieldHalf;
    public GameObject ShieldLow;

    public bool ShieldAlive = false;

    public Coroutine ShieldDestroy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("PlayerMain");
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthShield == 100)
        {
            ShieldFULL.SetActive(true);
            ShieldHalf.SetActive(false);
            ShieldLow.SetActive(false);
        }

        else if (HealthShield == 65)
        {
            ShieldFULL.SetActive(false);
            ShieldHalf.SetActive(true);
            ShieldLow.SetActive(false);
        }

        else if (HealthShield == 30)
        {
            ShieldFULL.SetActive(false);
            ShieldHalf.SetActive(false);
            ShieldLow.SetActive(true);
        }
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
                ShieldAlive = false;
                StopCoroutineExtra();
            }
        }
    }


    IEnumerator ShieldAutoDestroy()
    {
        yield return new WaitForSeconds(30f);
        if (ShieldAlive)
        {
            Player.GetComponent<SpellCasting>().FirstTimeShield--;
            Player.GetComponent<SpellCasting>().ActualShield.SetActive(false);
            HealthShield = 100;
        }

    }

    public void StartCoroutineExtra()
    {
        ShieldDestroy = StartCoroutine(ShieldAutoDestroy());
    }

    public void StopCoroutineExtra()
    {
        StopAllCoroutines();
    }
}
