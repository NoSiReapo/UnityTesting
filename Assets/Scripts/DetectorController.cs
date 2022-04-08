using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorController : MonoBehaviour
{
    public bool IsFlag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            IsFlag = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            IsFlag = false;
        }
    }
}
