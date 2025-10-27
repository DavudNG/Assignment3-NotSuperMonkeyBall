using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem myParticles;

    void Start()
    {
        myParticles.Stop();
        if (myParticles == null)
            myParticles = GetComponent<ParticleSystem>();

        // Make sure it doesn't play automatically
        myParticles.playOnAwake = false;
    }
}
