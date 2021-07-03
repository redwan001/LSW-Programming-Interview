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
        if(GameManager.instance.itemHeld[buttonValue] != "")
        {
            GameMenu.instance.SelectItem(GameManager.instance.GetItemDetails(GameManager.instance.itemHeld[buttonValue]));
        }
    }
}
