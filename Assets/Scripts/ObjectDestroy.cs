using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroyObject", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
