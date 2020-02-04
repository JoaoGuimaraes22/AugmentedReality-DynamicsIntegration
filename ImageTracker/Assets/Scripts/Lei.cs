using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lei : MonoBehaviour
{
    public GameObject lei;
    public Toggle toogleLei;

    private void Awake()
    {
        lei.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!toogleLei.isOn)
        {
            lei.SetActive(true);
          
        }
        if (toogleLei.isOn)
        {
            lei.SetActive(false);
        }
    }
}
