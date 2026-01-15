using UnityEngine;
using System.Windows.Input;
using NUnit.Framework;

public class SpellcastInputs : MonoBehaviour
{

    public int PageNum = 0;
    public string[] combos = new string[] {"qe", "frq", "qreeq", "efr", "fqereq", "erfqee", "rrr" } ;
    public string PlayerInput = "";
    public string CurrentCombo = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentCombo = combos[PageNum];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PageNum += 1;
            if (PageNum == 7) { PageNum = 0;}
            Debug.Log(PageNum);
            CurrentCombo = combos[PageNum];
            Debug.Log(CurrentCombo);
            
            
            

        }
    }
}
