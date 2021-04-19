using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    void Update()
    {
       transform.position += new Vector3(0,(-0.01f),0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "paddle")
        {
            Destroy(gameObject);
        }
    }
}
