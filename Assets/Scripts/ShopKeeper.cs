using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    private bool _canOpen;

    public string[] itemsForSale = new string[21];

    private void Update()
    {
        if(_canOpen && Input.GetButtonDown("Fire1") && PlayerController.instance.canMove && !ShopManager.instance.shopMenu.activeInHierarchy)
        {
            ShopManager.instance.itemsForSale = itemsForSale;
            ShopManager.instance.OpenShop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canOpen = false;
        }
    }
}
