using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AuthVerification : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject formObject;
    public GameObject auth;
    private ARTrackedImageManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<ARTrackedImageManager>();
        auth.SetActive(false);
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
        foreach (var img in args.added)
        {
            if (img.referenceImage.name.ToString() == "Logo" || img.referenceImage.name.ToString().Contains("extintor"))
            {
                if (auth.activeSelf)
                {
                    auth.SetActive(false);
                }

                formObject.SetActive(true);
            }
            if (img.referenceImage.name.ToString() == "QR")
            {
                auth.SetActive(true);
            }
        }
    }
}
