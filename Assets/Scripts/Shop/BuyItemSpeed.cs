using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemSpeed : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private float price;
    [SerializeField] private Button itemButton;
    [SerializeField] private Movement Movement;
    public Money Money;
    private bool isBought;

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
        else if (Money.money < price && !isBought)
        {
            Debug.Log("Not enough money");
        }
        else if (isBought)
        {
            Debug.Log("Item is already bought");
        }
    }
}

