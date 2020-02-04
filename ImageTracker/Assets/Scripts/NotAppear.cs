using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class NotAppear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objToAlter;
    public GameObject auth;
    private ARTrackedImageManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<ARTrackedImageManager>();
        objToAlter.SetActive(false);
    }

    private void OnEnable()
    {
        _manager.trackedImagesChanged += OnImgChanged;
    }

    private void OnDisable()
    {
        _manager.trackedImagesChanged -= OnImgChanged;
    }

    private void OnImgChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var img in args.added)
        {
            if (img.referenceImage.name.ToString() == "Logo")
            {
                if (auth.activeSelf)
                {
                    auth.SetActive(false);
                }

                objToAlter.SetActive(true);
            }
            if (img.referenceImage.name.ToString() == "QR")
            {
                objToAlter.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
