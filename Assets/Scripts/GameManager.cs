using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharacterStats[] playerStats;
    public GameObject npc, menu;

    public bool gameMenuOpen;
    public bool dailogeActive;

    public string[] itemHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;
    
    void Start()
    {

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    
     
        if (gameMenuOpen || dailogeActive)
        {
            PlayerController.instance.canMove = false;
        }
        else
            PlayerController.instance.canMove = true;
    }

    public Item GetItemDetails(string itemToGrab) 
    {
        for(int i = 0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].itemName == itemToGrab) {
                return referenceItems[i];
            }
        }

        return null;
    }



}
