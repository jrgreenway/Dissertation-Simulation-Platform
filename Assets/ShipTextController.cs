using TMPro;
using UnityEngine;

public class ShipHUD : MonoBehaviour
    // This class handles displaying ship statistics on the overlay at the top of the screen
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI headingText;       
    public TextMeshProUGUI positionText;
    public ShipController shipController;

    void Update()
    {
        // Update the speed text with the current speed of the ship
        speedText.text = "Speed: " + shipController.CurrentSpeed.ToString("F1");

        // Update the heading text with the current heading of the ship
        headingText.text = "Heading: " + shipController.CurrentHeading.ToString("F1") + "°";

        string positionx = shipController.CurrentPosition.x.ToString("F1");
        string positiony = shipController.CurrentPosition.y.ToString("F1");

        positionText.text = "Position: (" + positionx + "," + positiony + ")";
    }
}