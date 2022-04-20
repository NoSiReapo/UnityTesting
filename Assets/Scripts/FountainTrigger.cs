using UnityEngine;

public class FountainTrigger : MonoBehaviour
{
    public bool FountainEnterFlag;
    public bool FountainExitFlag;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fountain")
        {
            FountainEnterFlag = true;
            FountainExitFlag = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fountain")
        {
            FountainExitFlag = true;
            FountainEnterFlag = false;
        }
    }
    
}
