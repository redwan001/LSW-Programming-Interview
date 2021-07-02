using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{

    public GameObject menu;
    public CharacterStats[] playerStats;
    public Text nameText;
    public Image charImage;

    public ItemButton[] itemButtons;
    void Start()
    {

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
        nameText.text = playerStats[0].charName;
        charImage.sprite = playerStats[0].dress;
    }

    public void ShowItems()
    {
        for(int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if(GameManager.instance.itemHeld[i] != "")
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
}
