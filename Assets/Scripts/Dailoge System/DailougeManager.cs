using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DailougeManager : MonoBehaviour
{
    public static DailougeManager instance;
    public Text dailogText;
    public Text nameText;
    public GameObject dailogeBox;
    public GameObject nameBox;

    public string[] dailogeLines;

    public int currentLine;

    private bool _started;
    void Start()
    {
        instance = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (dailogeBox != null)
        {
            if (dailogeBox.activeInHierarchy)
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    if (!_started)
                    {
                        currentLine++;
                        if (currentLine >= dailogeLines.Length)
                        {
                            dailogeBox.SetActive(false);
                            GameManager.instance.dailogeActive = false;
                        }
                        else
                        {
                            ChechkIfName();
                            dailogText.text = dailogeLines[currentLine];
                        }
                    }
                    else
                        _started = false;
                }
            }
        }
    }
    public void ShowDailog(string[] newLines)
    {
        dailogeLines = newLines;
        currentLine = 0;
        ChechkIfName();
        dailogText.text = dailogeLines[currentLine];
        dailogeBox.SetActive(true);
        GameManager.instance.dailogeActive = true;
        _started = true;
    }

    public void ChechkIfName()
    {
        if(dailogeLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dailogeLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
}
