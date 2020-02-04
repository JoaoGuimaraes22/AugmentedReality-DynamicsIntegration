using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
    public GameObject formToAppear;
    public GameObject auth;

    private ARTrackedImageManager _arImgManager;

    private void Awake()
    {
        _arImgManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _arImgManager.trackedImagesChanged += OnImageChanged; 
    }

    private void OnDisable()
    {
        _arImgManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var img in args.added)
        {
            if (img.referenceImage.name.ToString() == "Logo")
            {
                if (auth.activeSelf)
                {
                    auth.SetActive(false);
                }
                formToAppear.SetActive(true);
            }
            if(img.referenceImage.name.ToString() == "QR")
            { 
                auth.SetActive(true);
            }
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
