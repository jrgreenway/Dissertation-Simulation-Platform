using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigurationLoader : MonoBehaviour
    //This script loads the model configuration data into the scene, applying text to display the model name at the top of the screen
{
    public TextMeshProUGUI text;

    void Start()
    {
        ApplyConfig();
    }

    void ApplyConfig()
    {
        text.text = SceneData.ModelVersionConfig.modelName.ToUpper();
    }
}
