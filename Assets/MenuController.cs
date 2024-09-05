using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
    // Each of the methods activate on button clicks in the main menu, loading the respective model configuration and scene.
{
    public ModelVersionConfig bertConfig;
    public ModelVersionConfig distilbertConfig;
    public ModelVersionConfig xlnetConfig;

    public void LoadBert()
    {
        StartCoroutine(ApiRunner.Run("bert"));
        LoadSceneWithConfig(bertConfig);
    }

    public void LoadDistilbert()
    {
        StartCoroutine(ApiRunner.Run("distilbert"));
        LoadSceneWithConfig(distilbertConfig);
    }

    public void LoadXlnet()
    {
        StartCoroutine(ApiRunner.Run("xlnet"));
        LoadSceneWithConfig(xlnetConfig);
    }

    void LoadSceneWithConfig(ModelVersionConfig config)
    {
        SceneData.ModelVersionConfig = config;
        SceneManager.LoadScene("Simulation");
    }
}

