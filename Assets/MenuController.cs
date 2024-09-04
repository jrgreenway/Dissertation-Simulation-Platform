using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public ModelVersionConfig bertConfig;
    public ModelVersionConfig distilbertConfig;
    public ModelVersionConfig xlnetConfig;

    public void LoadBert()
    {
        ApiRunner.Run("bert");
        LoadSceneWithConfig(bertConfig);
    }

    public void LoadDistilbert()
    {
        ApiRunner.Run("distilbert");
        LoadSceneWithConfig(distilbertConfig);
    }

    public void LoadXlnet()
    {
        ApiRunner.Run("xlnet");
        LoadSceneWithConfig(xlnetConfig);
    }

    void LoadSceneWithConfig(ModelVersionConfig config)
    {
        SceneData.ModelVersionConfig = config;
        SceneManager.LoadScene("Simulation");
    }
}

