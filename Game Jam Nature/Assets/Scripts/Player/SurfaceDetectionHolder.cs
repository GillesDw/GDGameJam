using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MaterialSoundRelation
{
    public Material _material;
    public Patch _soundObject;
}
public class SurfaceDetectionHolder : MonoBehaviour
{
    private Material material;

    private AudioSource _footstepSource;
    private SurfaceDetection _surfaceDetector;

    [SerializeField] private Patch _defaultSoundObject;
    [SerializeField] private List<MaterialSoundRelation> _relations;

    private void Awake()
    {
        _footstepSource = GetComponent<AudioSource>();
        _surfaceDetector = GetComponent<SurfaceDetection>();
    }

    private void PlayFootstep()
    {
        material = _surfaceDetector.CastForSurface();
        Patch patch = Map(material);
        patch.Play(_footstepSource);
    }
    public Patch Map(Material material)
    {
        foreach (MaterialSoundRelation entry in _relations)
        {
            if (entry._material == material)
            {
                return entry._soundObject;
            }
        }

        return _defaultSoundObject;
    }
}
