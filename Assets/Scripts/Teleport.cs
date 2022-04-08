using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]private GameObject Teleporter;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" & Input.GetKeyDown(KeyCode.T))
        {
            collision.transform.position = Teleporter.transform.position;
        }
    }
}
