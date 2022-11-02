using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    float timeStamp, doorStamp;

    [SerializeField]
    ParticleSystem particles;

    AudioSource doorNoise, sparkNoise;
    // Start is called before the first frame update
    void Start()
    {
        doorStamp = Time.time;
        timeStamp = Time.time;
        sparkNoise = particles.GetComponent<AudioSource>();
        doorNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeStamp + 1.3)
        {
            particles.Play();
            timeStamp = Time.time;
            sparkNoise.Play();
            if(Time.time > timeStamp + 0.25)
            {
                sparkNoise.Stop();
            }
        }
        if(Time.time > doorStamp + 1.75)
        {
            doorNoise.Play();
            doorStamp = Time.time;
        }

    }
}
