using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public GameObject shopMenu;
    public GameObject buyMenu;
    public GameObject sellMenu;

    public Text goldText;

    public string[] itemsForSale;
    public ItemButton[] buyItemButtons;
    public ItemButton[] sellItemButtons;


    public Item selectedItem;
    public Text buyItemName, buyItemDes, buyItemValue;
    public Text sellItemName, sellItemDes, sellItemValue;
    void Start()
    {
        instance = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenShop()
    {
        OpenBuyMenu();
        shopMenu.SetActive(true);
        GameManager.instance.shopActive = true;
        goldText.text = GameManager.instance.currentGold.ToString();
    }

    public void CloseShop() {

        shopMenu.SetActive(false);
        GameManager.instance.shopActive = false;
    }

    public void OpenBuyMenu()
    {
        buyItemButtons[0].Press();
        buyMenu.SetActive(true);
        sellMenu.SetActive(false);

        for (int i = 0; i < buyItemButtons.Length; i++)
        {
            buyItemButtons[i].buttonValue = i;

            if (itemsForSale[i] != "")
            {
                buyItemButtons[i].buttonImage.gameObject.SetActive(true);
                buyItemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(itemsForSale[i]).itemSprite;
                buyItemButtons[i].ammountText.text = "";
            }
            else
            {
                buyItemButtons[i].buttonImage.gameObject.SetActive(false);
                buyItemButtons[i].ammountText.text = "";
            }
        }


    }
    public void OpenSellMenu()
    {
        sellItemButtons[0].Press();
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);

        GameManager.instance.SortItems();
        for (int i = 0; i < sellItemButtons.Length; i++)
        {
            sellItemButtons[i].buttonValue = i;

            if (GameManager.instance.itemHeld[i] != "")
            {
                sellItemButtons[i].buttonImage.gameObject.SetActive(true);
                sellItemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[i]).itemSprite;
                sellItemButtons[i].ammountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                sellItemButtons[i].buttonImage.gameObject.SetActive(false);
                sellItemButtons[i].ammountText.text = "";
            }
        }
    }

    public void SelectBuyItem(Item buyItem)
    {
        selectedItem = buyItem;
        buyItemName.text = selectedItem.itemName;
        buyItemDes.text = selectedItem.description;
        buyItemValue.text = "Value: " + selectedItem.value;

    }
    public void SelectSellItem(Item sellItem)
    {
        if (sellItem != null)
        {
            selectedItem = sellItem;
            sellItemName.text = selectedItem.itemName;
            sellItemDes.text = selectedItem.description;
        }
            sellItemValue.text = "Value: " + Mathf.FloorToInt(selectedItem.value * .5f).ToString();

        
     
    }



    public void BuyItem()
    {
        if (selectedItem != null)
        {
            if (GameManager.instance.currentGold >= selectedItem.value)
            {
                GameManager.instance.currentGold -= selectedItem.value;
                GameManager.instance.AddItems(selectedItem.itemName);
            }
        }
        goldText.text = GameManager.instance.currentGold.ToString();
    }


    public void SellItem()
    {
        if (selectedItem != null)
        {

            GameManager.instance.currentGold += Mathf.FloorToInt(selectedItem.value * .5f);
            GameManager.instance.RemoveItem(selectedItem.itemName);
        }
        goldText.text = GameManager.instance.currentGold.ToString();

        for (int i = 0; i < sellItemButtons.Length; i++)
        {
            sellItemButtons[i].buttonValue = i;

            if (GameManager.instance.itemHeld[i] != "")
            {
                sellItemButtons[i].buttonImage.gameObject.SetActive(true);
                sellItemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[i]).itemSprite;
                sellItemButtons[i].ammountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                sellItemButtons[i].buttonImage.gameObject.SetActive(false);
                sellItemButtons[i].ammountText.text = "";
            }
        }


    }
}
