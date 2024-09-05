using UnityEngine;

public class ExitButtonController : MonoBehaviour
    // Attached to the exit button in the main menu to quit the application
{
    public void OnExitButtonPressed()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
