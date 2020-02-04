using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RectNotAppear : MonoBehaviour
{
    public GameObject rect;

    private void Awake()
    {
        rect.SetActive(false);
    }
  
    // Update is called once per frame
    void Update()
    {

    }
}
