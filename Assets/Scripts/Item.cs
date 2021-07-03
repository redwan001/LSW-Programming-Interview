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
                
            }
            selectedChar.equippedWpn = itemName;
        }
        if (isArmor)
        {
            if (selectedChar.equippedArmr != "")
            {

            }
            selectedChar.equippedArmr = itemName;
        }
    }
}
