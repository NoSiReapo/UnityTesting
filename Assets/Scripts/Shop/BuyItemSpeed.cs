using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemSpeed : MonoBehaviour
{
    [SerializeField] private bool isBought;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private float price;
    [SerializeField] private Button itemButton;
    public Movement Movement;
    public Money Money;


    private void Start()
    {
        isBought = false;
        priceText.text = price + "$";
    }
    private void Update()
    {
        ButtonStatus();
    }

    private void ButtonStatus()
    {
        if (isBought)
        {
            priceText.text = "SOLD";
            isBought = true;
            itemButton.image.color = Color.grey;
        }
    }

    public void Buy()
    {
        if (Money.money >= price && !isBought)
        {
            Money.money -= price;
            priceText.text = "SOLD";
            isBought = true;
            Movement.MoveSpeed += 3;
        }
    }

}
