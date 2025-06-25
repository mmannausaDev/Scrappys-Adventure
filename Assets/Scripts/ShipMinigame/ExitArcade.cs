using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ExitArcade : MonoBehaviour
{
    [SerializeField] GameObject stuffToBringBack;
    [SerializeField] private ScriptableRendererFeature _rendererFeature;

    [SerializeField] ShopDialog shopDialog;

    public void exitTheArcade()
    {
        stuffToBringBack.SetActive(true);
        _rendererFeature.SetActive(false);

        shopDialog.triggerDialogEndArcade();
    }

}
