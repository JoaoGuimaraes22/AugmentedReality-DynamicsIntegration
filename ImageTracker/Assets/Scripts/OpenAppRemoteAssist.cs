using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAppRemoteAssist : MonoBehaviour
{
   
    public void openApp()
    {
        bool fail = false;
        string bundleId = "com.microsoft.ramobile"; // your target bundle id
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

        AndroidJavaObject launchIntent = null;
        try
        {
            launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleId);
        }
        catch (System.Exception e)
        {
            fail = true;
            Debug.Log(e);
        }

        if (fail)
        { //open app in store
            Application.OpenURL("https://google.com");
        }
        else //open the app
            ca.Call("startActivity", launchIntent);

        up.Dispose();
        ca.Dispose();
        packageManager.Dispose();
        launchIntent.Dispose();
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
