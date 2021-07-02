using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailogeActivator : MonoBehaviour
{
    public string[] lines;
    public bool canActivate;
    public GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetButtonDown("Fire1") && !DailougeManager.instance.dailogeBox.activeInHierarchy && !GameManager.instance.gameMenuOpen)
        {
            DailougeManager.instance.ShowDailog(lines); canvas.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivate = true;
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivate = false;
            canvas.gameObject.SetActive(false);
        }
    }
}
