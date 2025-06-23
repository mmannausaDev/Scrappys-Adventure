using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class enableRendererFeature : MonoBehaviour
{
    [SerializeField] private ScriptableRendererFeature _rendererFeature;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_rendererFeature == null) return;

        if (scene.name == "Ship minigame")
        {
            _rendererFeature.SetActive(true);
        }
        else
        {
            _rendererFeature.SetActive(false);
        }
    }
}