using UnityEngine;

public class ExitButtonController : MonoBehaviour
{
    public void OnExitButtonPressed()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
