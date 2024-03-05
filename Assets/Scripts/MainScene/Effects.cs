using Unity.VisualScripting;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem crashEffect;

    [SerializeField]
    private AudioSource carAudioSource;

    [SerializeField]
    private AudioSource AudioEffectSource;

    [SerializeField]
    private float nitroEnginePitch;

    [SerializeField]
    private AudioClip fuelGatherClip;

    [SerializeField]
    private AudioClip crashClip;

    [SerializeField]
    private AudioClip SqueakySound;

    private float normalEnginePitch;

    public void Awake()
    {
        normalEnginePitch = carAudioSource.pitch;
    }

    public void GatherFuel(int value)
    {
        if (value > 0)
        {
            AudioEffectSource.PlayOneShot(fuelGatherClip);
        }
    }

    public void ObstacleHit(int value)
    {
        //here it was value < 0
        if (Player.IsAlive && value < 0)
        {
            AudioEffectSource.PlayOneShot(SqueakySound);
        }
    }

    public void OnDeathActivateParticle(bool isDeath)
    {
        if (isDeath)
        {
            crashEffect.gameObject.SetActive(true);
            crashEffect.Play();
        }
    }

    public void OnDeathActivateSound(bool isDeath)
    {
        if(isDeath)
        {
            AudioEffectSource.clip = crashClip;
            AudioEffectSource.Play();
        }
    }
}
