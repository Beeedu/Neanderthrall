using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource pfThrowSound;
    private AudioSource throwSound;

    [SerializeField]
    private AudioSource pfImpactSound;
    private AudioSource impactSound;

    private readonly List<AudioSource> sounds = new List<AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        this.throwSound = InstantiateSound(pfThrowSound);
        this.impactSound = InstantiateSound(pfImpactSound);
    }

    private void OnDestroy()
    {
        sounds.ForEach((sound) => Destroy(sound));
    }

    private AudioSource InstantiateSound(AudioSource prefab)
    {
        AudioSource sound = Instantiate(prefab, this.transform);
        sounds.Add(sound);
        return sound.GetComponent<AudioSource>();
    }

    public void PlayThrowSound()
    {
        this.throwSound.Play();
    }

    public void PlayImpactSound()
    {
        this.impactSound.Play();
    }
}
