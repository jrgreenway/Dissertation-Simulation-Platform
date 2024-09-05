using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackButtonController : MonoBehaviour
    // This script is attached to the back button in the Ship scene
{
    public string previousSceneName;

    public void OnBackButtonPressed()
        // This function is called when the back button is pressed to return to the previous scene
    {
        SceneManager.LoadScene(previousSceneName);
    }

}
