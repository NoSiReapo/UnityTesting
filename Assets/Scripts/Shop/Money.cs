using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public float money;
    [SerializeField] private TMP_Text moneyText;

    private void Start()
    {
        money = 100f;   
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("money", money); 
        moneyText.text = money.ToString() + "$";  

    }
}    
