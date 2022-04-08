using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    public bool WallsFlag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Walls")
        {
            WallsFlag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Walls")
        {
            WallsFlag = false;
        }
    }
}
