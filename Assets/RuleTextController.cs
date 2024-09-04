using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class RuleTextController : MonoBehaviour
{
    public TextMeshProUGUI responseText; 
    public ShipController shipController;
    private float timeSinceLastCall = 0f;
    public float callInterval = 5f;

    void Start()
    {
        StartCoroutine(CallAPI());
    }

    IEnumerator CallAPI()
    {
        string apiURL = "https://127.0.0.1:8000/get";

        float shipSpeed = shipController.CurrentSpeed;
        Vector3 shipPosition = shipController.transform.position;
        float shipHeading = shipController.CurrentHeading;
        WWWForm form = new WWWForm();
        form.AddField("Speed_2", shipSpeed.ToString());
        form.AddField("X_2", shipPosition.x.ToString());
        form.AddField("Y_2", shipPosition.y.ToString());
        form.AddField("Heading_2", shipHeading.ToString());

        UnityWebRequest request = UnityWebRequest.Post(apiURL, form);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            responseText.text = "Error: " + request.error;
        }
        else
        {

            string responseData = request.downloadHandler.text;
            responseText.text = "Rule: " + responseData;
        }
    }

    void Update()
    {
        // Update the time since the last API call
        timeSinceLastCall += Time.deltaTime;

        // Call API every 'callInterval' seconds
        if (timeSinceLastCall >= callInterval)
        {
            StartCoroutine(CallAPI());
            timeSinceLastCall = 0f; // Reset the timer
        }
    }
}
