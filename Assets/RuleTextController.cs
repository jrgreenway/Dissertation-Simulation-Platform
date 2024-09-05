using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

[System.Serializable]
public class RuleResponse
{
    public string label;
}
public class ShipData
{
    public float Speed_2;
    public float X_2;
    public float Y_2;
    public float Heading_2;
}

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
        // This function sends a POST request to the API with the current ship data, receives a response, and displays the rule in the UI
    {
        string apiURL = "http://127.0.0.1:8000/get";
        float shipSpeed = (shipController.CurrentSpeed/20)*(25);
        Vector3 shipPosition = shipController.transform.position;
        float shipHeading = shipController.CurrentHeading;
        ShipData shipData = new ShipData
        {
            Speed_2 = shipSpeed,
            X_2 = shipPosition.x,
            Y_2 = shipPosition.y,
            Heading_2 = shipHeading
        };
        string jsonPayload = JsonUtility.ToJson(shipData);
        Debug.Log("Sending JSON: " + jsonPayload);
        UnityWebRequest request = new UnityWebRequest(apiURL, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            responseText.text = "Error: " + request.error;
        }
        else
        {
            string responseData = request.downloadHandler.text;
            RuleResponse ruleResponse = JsonUtility.FromJson<RuleResponse>(responseData);
            responseText.text = "Rule: " + ruleResponse.label;
            Debug.Log("Response: " + responseData);
        }
    }

    void Update()
    {
        timeSinceLastCall += Time.deltaTime;
        if (timeSinceLastCall >= callInterval)
        {
            StartCoroutine(CallAPI());
            timeSinceLastCall = 0f;
        }
    }
}
