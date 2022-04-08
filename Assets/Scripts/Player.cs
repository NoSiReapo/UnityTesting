using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private GameObject GameObject;
    private void Start()
    {
        
    }

    private void Update()
    {
        EventBus.Movements?.Invoke();
    }

}
