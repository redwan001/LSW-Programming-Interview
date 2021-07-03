using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    public GameObject menu;
    public CharacterStats[] playerStats;
    public Text nameText, armorName, weaponName;
    public Image charImage;
    public GameObject itemPanel;

    public ItemButton[] itemButtons;
    public string selectedItem;
    public Item activeItem ;
    public Text itemName, itemDes, useBtnText ;
    public Text goldText;
    void Start()
    {
        instance = this;
    }


    void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
            }
            else
            {
                if (!GameManager.instance.dailogeActive)
                {
                    UpdateStats();
                    menu.SetActive(true);
                    GameManager.instance.gameMenuOpen = true;
                }
            }
        }
    }
    public void UpdateStats()
    {
        if(goldText != null)
        goldText.text = GameManager.instance.currentGold.ToString();
        nameText.text = playerStats[0].charName;
        charImage.sprite = playerStats[0].dress;
        armorName.text = playerStats[0].equippedArmr;
        weaponName.text = playerStats[0].equippedWpn;
    }


    public void ShowItems()
    {
        GameManager.instance.SortItems();

        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if (GameManager.instance.itemHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[i]).itemSprite;
                itemButtons[i].ammountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].ammountText.text = "";
            }
        }
    }

    public void 
        ItemPanelEnable()
    {
        itemPanel.SetActive(true);
    }

    public void SelectItem(Item newitem)
    {
        activeItem = newitem;
        if(activeItem.isItem)
        {
            useBtnText.text = "Use";
        }
        if(activeItem.isWeapon || activeItem.isArmor)
        {
            useBtnText.text = "Equip";
        }

        itemName.text = activeItem.itemName;
        itemDes.text = activeItem.description;
    }

    public void UseItem()
    {
        activeItem.Use();
    }
}
