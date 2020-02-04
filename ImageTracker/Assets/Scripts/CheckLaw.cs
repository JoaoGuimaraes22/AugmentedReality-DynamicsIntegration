using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLaw : MonoBehaviour
{
    public Toggle _lawToggle;
    public GameObject rect;

    public void Checker()
    {
        if (!_lawToggle.isOn)
        {
            rect.SetActive(true);
        }

        if (_lawToggle.isOn)
        {
            rect.SetActive(false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
