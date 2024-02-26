using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
