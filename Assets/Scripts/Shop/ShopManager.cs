using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject ShopObject;
    [SerializeField] private TMP_Text ButtonText;
    private bool IsShop;

    private void Start()
    {
        IsShop = true;
        ButtonText.text = "Enabled";
        ShopObject.SetActive(true);
    }
    private void Update()
    {
      
    }
    public void ShopVisible()
    {
        if (IsShop)
        {
            ButtonText.text = "Disabled";
            ShopObject.SetActive(false);
            IsShop = false;
        }
        else if (!IsShop)
        {
            ButtonText.text = "Enabled";
            ShopObject.SetActive(true);
            IsShop = true;
        }
    }
}
