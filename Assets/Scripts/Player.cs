using UnityEngine;


public class Player : MonoBehaviour
{
    private void Update()
    {
        EventBus.Movements?.Invoke();
    }
}
