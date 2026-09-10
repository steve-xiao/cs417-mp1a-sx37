using UnityEngine;

public class FeedbackGroup : MonoBehaviour
{
    public ParticleSystem[] particles;
    public AudioSource[] sounds;

    public void PlayFeedback()
    {
        foreach (ParticleSystem p in particles)
        {
            if (p != null)
            {
                p.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                p.Play();
            }
        }

        foreach (AudioSource s in sounds)
        {
            if (s != null)
            {
                s.Stop();
                s.Play();
            }
        }
    }
}