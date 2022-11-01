using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghoulControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    bool playerFound = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if(player.lookingAtMonster)
            {
                playerFound = true;
            }
            
        }
    }
}
