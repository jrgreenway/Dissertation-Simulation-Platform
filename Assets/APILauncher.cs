using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class ApiRunner
{ 
    public static IEnumerator Run(string args)
    {
        string url = "http://localhost:8000/model";

        string req = "{\"model\": \"" + args + "\"}";
        Debug.Log("Sending JSON payload: " + req);
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(req);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Request error: {request.error}");
        }
        else
        {
            Debug.Log($"Response: {request.downloadHandler.text}");
        }
    }
}
