using UnityEngine;


[CreateAssetMenu(fileName = "ModelVersionConfig", menuName = "Config/ModelVersionConfig")]
public class ModelVersionConfig : ScriptableObject
    // A ScriptableObject to store the model name across scenes
{
    public string modelName;
}
