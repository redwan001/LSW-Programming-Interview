using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    // Start is called before the first frame update
    public string areaToLoad;

    public string areaTrasitionName;

    public AreaEntrance theEntrance;

    

    private void Start()
    {
        theEntrance.transitionName = areaTrasitionName;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SceneManager.LoadScene(areaToLoad);
        PlayerController.instance.areanTrasitionName = areaTrasitionName;
    }
}
