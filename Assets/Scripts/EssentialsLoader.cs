using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour {

    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameMan;
    public GameObject audioMan;
    public GameObject battleMan;

	// Use this for initialization
	void Start () {
		if(UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }

  

        if (GameManager.instance == null)
        {
            GameManager.instance = Instantiate(gameMan).GetComponent<GameManager>();
        }

    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
