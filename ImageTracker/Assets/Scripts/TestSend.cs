using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestSend : MonoBehaviour
{
    public Toggle ToogleOne;
    public Toggle ToogleTwo;
    public InputField InputText;
    readonly string BaseUrl = "https://prod-42.westeurope.logic.azure.com:443/workflows/291bfb34679c4f789aaed9f65f10541c/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=NcQujo3zMZPwZ-fl2jQSl9nl3guu29Frd2cnCA0TGyU";


    public void Begin()
    {
        StartCoroutine(Upload());
    }


    IEnumerator Upload()
    {

        byte[] toogleOne = Encoding.UTF8.GetBytes(ToogleOne.isOn.ToString());
        byte[] toogleTwo = Encoding.UTF8.GetBytes(ToogleOne.isOn.ToString());
        byte[] inputText = Encoding.UTF8.GetBytes(InputText.text);
        byte[] date = Encoding.UTF8.GetBytes(DateTime.Now.ToString());

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormFileSection("ToogleOne", ToogleOne.isOn.ToString()));
        formData.Add(new MultipartFormFileSection("ToogleTwo", ToogleOne.isOn.ToString()));
        formData.Add(new MultipartFormFileSection("InputText", InputText.text));
        formData.Add(new MultipartFormFileSection("Date", DateTime.Now.ToString()));

        UnityWebRequest www = UnityWebRequest.Post(BaseUrl, formData);
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

}
