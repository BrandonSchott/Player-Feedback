using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    bool buttonPressed = false;

    [SerializeField]
    GameObject doors, ghost, panel, box;

    [SerializeField]
    RenderTexture texture;

    [SerializeField]
    Light buttonLight, lightbulb;

    [SerializeField]
    ParticleSystem smoke;

    Light light;

    AudioSource music, lightaudio, boxAudio;
    float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        timeStamp = Time.time;
        light = lightbulb.GetComponent<Light>();
        lightaudio = buttonLight.GetComponent<AudioSource>();
        boxAudio = box.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            doors.SetActive(false);
            buttonLight.enabled = false;
            lightbulb.color = Color.red;
            ghost.SetActive(true);
            if (!smoke.isPlaying)
            {
                smoke.Play();
                AudioSource smokeAudio = smoke.GetComponent<AudioSource>();
                smokeAudio.Play();
                music.Stop();
            }

            panel.GetComponent<Renderer>().material.mainTexture = texture;
        }
        else
        {
            if(!light.enabled && Time.time > timeStamp + 0.5)
            {
                light.enabled = !light.enabled;
                timeStamp = Time.time;
                lightaudio.Play();
            }
            else if(Time.time > timeStamp + 1)
            {
                light.enabled = !light.enabled;
                timeStamp = Time.time;
            }

        }
        boxAudio.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                buttonPressed = true;
            }
        }
    }
}
