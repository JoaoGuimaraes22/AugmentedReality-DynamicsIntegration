using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript1 : MonoBehaviour
{
    public GameObject form;
    public InputField _inputField;
    public GameObject lei;

    public GameObject rect;
    
    public void OnSubmit()
    {
        if (_inputField.text == "" || _inputField.text == " ")
        {
            rect.SetActive(true);
        }
        else
        {
            rect.SetActive(false);
            lei.SetActive(false);
            form.SetActive(false);
            
        }
    }
}
