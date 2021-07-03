using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;


    // Use this for initialization
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

    }
}
