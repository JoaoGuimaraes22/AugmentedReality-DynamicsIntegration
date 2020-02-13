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

        string url = "https://prod-47.westeurope.logic.azure.com:443/workflows/d240ca70ef944676b6bdac9f546a2a85";

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormFileSection("toogle1", ToogleOne.isOn.ToString()));
        formData.Add(new MultipartFormFileSection("toogle2", ToogleTwo.isOn.ToString()));
        formData.Add(new MultipartFormFileSection("inputText", InputText.text));

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
