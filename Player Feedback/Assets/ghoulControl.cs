using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghoulControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    AudioSource scream;

    bool playerFound = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        scream = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerFound)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(Vector3.forward * 20 * Time.deltaTime);
        }
    }

    public void PlayerLooking()
    {
        playerFound = true;
        if (!scream.isPlaying)
        {
            scream.Play();
        }
    }
}
