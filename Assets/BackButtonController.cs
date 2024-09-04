using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackButtonController : MonoBehaviour
{
    public string previousSceneName; // Assign the name of the previous scene in the Inspector

    public void OnBackButtonPressed()
    {
        StartCoroutine(CallShutdownAPIAndNavigate());
    }

    IEnumerator CallShutdownAPIAndNavigate()
    {
        string apiURL = "https://127.0.0.1:8000/shutdown";

        UnityWebRequest request = UnityWebRequest.Get(apiURL);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error calling shutdown API: " + request.error);
        }
        else
        {
            SceneManager.LoadScene(previousSceneName);
        }
    }
}

