using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public Text ammountText;
    public int buttonValue;


    public void Press()
    {
        if (GameMenu.instance.menu.activeInHierarchy)
        {

            if (GameManager.instance.itemHeld[buttonValue] != "")
            {
                GameMenu.instance.SelectItem(GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[buttonValue]));
            }
        }
        if (ShopManager.instance != null)
        {
            if (ShopManager.instance.shopMenu.activeInHierarchy)
            {
                if (ShopManager.instance.sellMenu.activeInHierarchy)
                {
                    ShopManager.instance.SelectSellItem(GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[buttonValue]));
                }
                if (ShopManager.instance.buyMenu.activeInHierarchy)
                {
                    ShopManager.instance.SelectBuyItem(GameManager.instance.GetItemDetails(ShopManager.instance.itemsForSale[buttonValue]));
                }
            }
        }
    }
}
