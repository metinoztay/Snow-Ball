using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SnowBall")
        {
            Destroy(collision);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
