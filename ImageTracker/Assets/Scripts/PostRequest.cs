using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostRequest : MonoBehaviour
{
    public Toggle ToogleOne;
    public Toggle ToogleTwo;
    public InputField InputText;
    string coordinates;
    readonly string BaseUrl = "https://prod-50.westeurope.logic.azure.com:443/workflows/c349e7ef97b647fa817c1b531974f7d1/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=av7rXg0NXfJNLyo_iCMHdf0vUm1FOgEiGOmXJ6CVUno";

    public void Begin()
    {
        coordinates = $"Lat: {GPS.Instance.latitude.ToString()} Lon: {GPS.Instance.longitude.ToString()}";
        var request = CreateApiPostRequest(BaseUrl, new ApiAuthenticateRequest { ToogleOne = ToogleOne.isOn.ToString(), ToogleTwo = ToogleOne.isOn.ToString(), InputText = InputText.text, Date = DateTime.Now.ToString(), GeoLocation = coordinates });;
        request.SendWebRequest();
    }


    public UnityWebRequest CreateApiPostRequest(string url, object body = null)
    {
        return CreateApiRequest(url, UnityWebRequest.kHttpVerbPOST, body);
    }

    UnityWebRequest CreateApiRequest(string url, string method, object body)
    {
        string bodyString = null;
        if (body is string)
        {
            bodyString = (string)body;
        }
        else if (body != null)
        {
            bodyString = JsonUtility.ToJson(body);
        }

        var request = new UnityWebRequest();
        request.url = url;
        request.method = method;
        request.downloadHandler = new DownloadHandlerBuffer();
        request.uploadHandler = new UploadHandlerRaw(string.IsNullOrEmpty(bodyString) ? null : Encoding.UTF8.GetBytes(bodyString));
        request.SetRequestHeader("Accept", "application/json");
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = 60;
        return request;
    }


    [Serializable]
    public class ApiAuthenticateRequest
    {
        public string ToogleOne;
        public string ToogleTwo;
        public string InputText;
        public string Date;
        public string GeoLocation;
    }




  

}
