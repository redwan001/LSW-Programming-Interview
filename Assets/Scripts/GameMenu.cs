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
}
