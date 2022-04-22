using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemSize : MonoBehaviour
{
    [SerializeField] private bool isBought;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private float price;
    [SerializeField] private Button itemButton;
    public Money Money;
    public ShopManager shopManager;

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
            shopManager.xSize += 2f;
            shopManager.ySize += 2f;
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
