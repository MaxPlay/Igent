using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GraphicsController : MonoBehaviour
{

    public Color ActiveColor;

    public RectTransform Anchor;
    public Image[] AntiAliasing;
    public Image[] Anisotropic;
    public Image[] TextureQuality;
    public Image[] VSync;
    public Slider ShadowDistSlider;

    void Start()
    {
        //SetAntialiasingButtonColor
        switch (QualitySettings.antiAliasing)
        {
            case 0:
                AntiAliasing[0].color = ActiveColor;
                break;
            case 2:
                AntiAliasing[1].color = ActiveColor;
                break;
            case 4:
                AntiAliasing[2].color = ActiveColor;
                break;
            case 8:
                AntiAliasing[3].color = ActiveColor;
                break;
        }

        //SetAnisotropicFilteringButtonColor
        switch (QualitySettings.anisotropicFiltering)
        {
            case AnisotropicFiltering.Disable:
                Anisotropic[0].color = ActiveColor;
                break;
            case AnisotropicFiltering.Enable:
                Anisotropic[1].color = ActiveColor;
                break;
            case AnisotropicFiltering.ForceEnable:
                Anisotropic[2].color = ActiveColor;
                break;
        }

        //SetTextureQualityLevel (uses mipmaps as new main Tex)
        TextureQuality[QualitySettings.masterTextureLimit].color = ActiveColor;

        VSync[QualitySettings.vSyncCount].color = ActiveColor;

        ShadowDistSlider.value = QualitySettings.shadowDistance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAA(int AntiAliasingValue)
    {
        foreach (Image i in AntiAliasing)
            i.color = Color.white;

        switch (AntiAliasingValue)
        {
            case 0:
                AntiAliasing[0].color = ActiveColor;
                break;
            case 2:
                AntiAliasing[1].color = ActiveColor;
                break;
            case 4:
                AntiAliasing[2].color = ActiveColor;
                break;
            case 8:
                AntiAliasing[3].color = ActiveColor;
                break;
        }

        QualitySettings.antiAliasing = AntiAliasingValue;
    }

    public void setAniso(int AnisotropicValue)
    {
        foreach (Image i in Anisotropic)
            i.color = Color.white;

        switch (AnisotropicValue)
        {
            case 0:
                Anisotropic[0].color = ActiveColor;
                break;
            case 1:
                Anisotropic[1].color = ActiveColor;
                break;
            case 2:
                Anisotropic[2].color = ActiveColor;
                break;
        }

        switch (AnisotropicValue)
        {
            case 0:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                break;
            case 2:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                break;
        }
    }

    public void setTexQuali(int Depth)
    {
        foreach (Image i in TextureQuality)
            i.color = Color.white;

        TextureQuality[Depth].color = ActiveColor;

        QualitySettings.masterTextureLimit = Depth;
    }

    public void setVSync(int Value)
    {
        foreach (Image i in VSync)
            i.color = Color.white;

        VSync[Value].color = ActiveColor;

        QualitySettings.vSyncCount = Value;
    }

    public void setShadowDist()
    {
        QualitySettings.shadowDistance = (int)ShadowDistSlider.value;
    }
}
