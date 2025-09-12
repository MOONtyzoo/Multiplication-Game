using UnityEngine;

public class HoverSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayHoverSound()
    {
        audioSource.Play();
    }
}
