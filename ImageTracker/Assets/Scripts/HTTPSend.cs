using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HTTPSend : MonoBehaviour
{
    public Toggle ToogleOne;
    public Toggle ToogleTwo;
    public InputField InputText;

    public void Begin()
    {
        StartCoroutine(Upload());
    }


    IEnumerator Upload()
    {

        string url = "https://prod-42.westeurope.logic.azure.com:443/workflows/291bfb34679c4f789aaed9f65f10541c/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=KrIctjAR-KhNmt6M-A5fXo_kfoGmk2C5aFeu_Y0oU38";

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormFileSection("toogle1", ToogleOne.isOn.ToString()));
        formData.Add(new MultipartFormFileSection("toogle2", ToogleTwo.isOn.ToString()));
        formData.Add(new MultipartFormFileSection("inputText", InputText.text));
        formData.Add(new MultipartFormFileSection("date", System.DateTime.Now.ToString()));

        UnityWebRequest www = UnityWebRequest.Post(url, formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

   

    // Update is called once per frame
    
}
