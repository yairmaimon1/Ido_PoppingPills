using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class ServerManager : MonoBehaviour
{
    
    public void OnButtonClick()
    {
        Debug.Log("button clicked..");
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("vite_b87f2dabce0223542f5c708e6c13418b486367addbbe797238", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
    /*
    public void OnButtonClick()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes("This is some test data");
        UnityWebRequest www = UnityWebRequest.Put("https://rpc.vitaminion.dev", myData);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }
    }*/

}
