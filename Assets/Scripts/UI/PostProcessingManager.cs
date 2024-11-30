using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private Volume _postProcessingVolume;
    private ChromaticAberration _chromaticAberration;
    private PaniniProjection _paniniProjection;

    private void Start()
    {
        if (_postProcessingVolume.profile == null)
        {
            
            return;
        }

        if (!_postProcessingVolume.profile.TryGet(out _chromaticAberration))
        {
            _chromaticAberration = _postProcessingVolume.profile.Add<ChromaticAberration>(true);
            
        }

        if (!_postProcessingVolume.profile.TryGet(out _paniniProjection))
        {
            _paniniProjection = _postProcessingVolume.profile.Add<PaniniProjection>(true);
            
        }
    }

    public void UpdateEffects(float healthPercentage)
    {
        if (_chromaticAberration != null)
        {
            float newIntensity = Mathf.Lerp(0.0f, 1.0f, 1.0f - healthPercentage);
            _chromaticAberration.intensity.value = newIntensity;
           
        }
      

        if (_paniniProjection != null)
        {
            float newDistance = Mathf.Lerp(0.0f, 1.0f, 1.0f - healthPercentage);
            _paniniProjection.distance.value = newDistance;
           
        }
     
    }
}