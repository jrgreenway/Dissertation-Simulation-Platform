using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigurationLoader : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        ApplyConfig();
    }

    // Update is called once per frame
    void ApplyConfig()
    {
        text.text = SceneData.ModelVersionConfig.modelName.ToUpper();
    }
}
