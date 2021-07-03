using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharacterStats[] playerStats;
    public GameObject npc, menu;

    public bool gameMenuOpen;
    public bool dailogeActive;
    public bool shopActive;

    public string[] itemHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;

    public int currentGold;



    void Start()
    {

        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (gameMenuOpen || dailogeActive || shopActive)
        {
            PlayerController.instance.canMove = false;
        }
        else
            PlayerController.instance.canMove = true;

        if (Input.GetKeyDown(KeyCode.J))
        {
            AddItems("Iron Sword");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RemoveItem("Iron Sword");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadData();
        }

    }

    public Item GetItemDetails(string itemToGrab)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].itemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }

        return null;
    }
    public void SortItems()
    {
        bool itemAFterSpace = true;

        while (itemAFterSpace)
        {
            itemAFterSpace = false;
            for (int i = 0; i < itemHeld.Length - 1; i++)
            {
                if (itemHeld[i] == "")
                {
                    itemHeld[i] = itemHeld[i + 1];
                    itemHeld[i + 1] = "";

                    numberOfItems[i] = numberOfItems[i + 1];
                    numberOfItems[i + 1] = 0;

                    if (itemHeld[i] != "")
                    {
                        itemAFterSpace = true;
                    }
                }
            }
        }
    }
    public void AddItems(string itemToAdd)
    {
        int newItemPos = 0;
        bool foundEmpty = false;
        for (int i = 0; i < itemHeld.Length; i++)
        {
            if (itemHeld[i] == "" || itemHeld[i] == itemToAdd)
            {
                newItemPos = i;
                i = itemHeld.Length;
                foundEmpty = true;
            }
        }
        if (foundEmpty)
        {
            bool itemExist = false;
            for (int i = 0; i < referenceItems.Length; i++)
            {
                if (referenceItems[i].itemName == itemToAdd)
                {
                    itemExist = true;
                    i = referenceItems.Length;
                }
            }
            if (itemExist)
            {
                itemHeld[newItemPos] = itemToAdd;
                numberOfItems[newItemPos]++;
            }
            else
                Debug.LogError("stop");
        }
        GameMenu.instance.ShowItems();

    }
    public void RemoveItem(string itemToRemove)
    {
        bool foundItem = false;
        int itemPosition = 0;

        for (int i = 0; i < itemHeld.Length; i++)
        {
            if (itemHeld[i] == itemToRemove)
            {
                foundItem = true;
                itemPosition = i;

                i = itemHeld.Length;
            }
        }

        if (foundItem)
        {
            numberOfItems[itemPosition]--;

            if (numberOfItems[itemPosition] <= 0)
            {
                itemHeld[itemPosition] = "";
            }

            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError("Couldn't find " + itemToRemove);
        }
    }


    public void SaveData()
    {
        //store inventory data
        for (int i = 0; i < itemHeld.Length; i++)
        {
            PlayerPrefs.SetString("ItemInInventory_" + i, itemHeld[i]);
            PlayerPrefs.SetInt("ItemAmount_" + i, numberOfItems[i]);
        }
    }
    public void LoadData()
    {
        for (int i = 0; i < itemHeld.Length; i++)
        {
            itemHeld[i] = PlayerPrefs.GetString("ItemInInventory_" + i);
            numberOfItems[i] = PlayerPrefs.GetInt("ItemAmount_" + i);
        }
    }
}
