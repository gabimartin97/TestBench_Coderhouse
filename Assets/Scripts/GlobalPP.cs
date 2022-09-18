using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GlobalPP : MonoBehaviour
{
    PostProcessVolume PostProcessVolume;
    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume = GetComponent<PostProcessVolume>();
        SpecialEnemy.OnDead += ClearRedBorders;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRedBorders()
    {
        Vignette vignette;
        if (PostProcessVolume.profile.TryGetSettings<Vignette>(out vignette))
        {
            vignette.color.overrideState = true;
            vignette.intensity.value = 0.75f;
        }

    }

    public void ClearRedBorders(int points)
    {
        Vignette vignette;
        if (PostProcessVolume.profile.TryGetSettings<Vignette>(out vignette))
        {
            vignette.active = false;
        }
    }
}
