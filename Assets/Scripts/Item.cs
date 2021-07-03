using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;
    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;
    public int ammountTaoChange;

    [Header("Weapon/Armor Details")]
    public int weaponStrength;
    public int armorStrength;

public void Use()
    {
        CharacterStats selectedChar = GameManager.instance.playerStats[0];
        if(isItem)
        {
            //increase Hp
        }
        if(isWeapon)
        {
            if(selectedChar.equippedWpn != "")
            {
                GameManager.instance.AddItems(selectedChar.equippedWpn);
            }
            selectedChar.equippedWpn = itemName;
        }
        if (isArmor)
        {
            if (selectedChar.equippedArmr != "")
            {
                GameManager.instance.AddItems(selectedChar.equippedArmr);
            }
            selectedChar.equippedArmr = itemName;
        }
        GameManager.instance.RemoveItem(itemName);
    }
}
