using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Soul2"))
        {
            Destroy(other.gameObject);
        }
    }
}
