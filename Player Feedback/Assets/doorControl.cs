using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    float timeStamp;

    [SerializeField]
    ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeStamp + 1.3)
        {
            particles.Play();
            timeStamp = Time.time;
        }
    }
}
