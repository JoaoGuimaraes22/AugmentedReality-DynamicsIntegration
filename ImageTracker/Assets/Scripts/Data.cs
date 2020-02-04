using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{

    public GameObject auth;
    public Text todayDate;
    private string date;
    

    // Start is called before the first frame update
    void Start()
    {
        date = DateTime.Now.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (auth.activeSelf)
        {
            todayDate.text = $"Data: {date}";
        }

    }
}
