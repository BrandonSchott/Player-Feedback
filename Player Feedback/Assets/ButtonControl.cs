using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    bool buttonPressed = false;

    [SerializeField]
    GameObject doors, ghost, panel;

    [SerializeField]
    RenderTexture texture;

    [SerializeField]
    Light buttonLight, Lightbulb;

    [SerializeField]
    ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            doors.SetActive(false);
            buttonLight.enabled = false;
            Lightbulb.color = Color.red;
            ghost.SetActive(true);
            if (!smoke.isPlaying)
            {
                smoke.Play();
            }

            panel.GetComponent<Renderer>().material.mainTexture = texture;
        }
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
