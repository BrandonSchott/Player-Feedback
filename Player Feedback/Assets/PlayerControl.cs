using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float hInput, vInput;
    float mouseX, mouseY, movementSpeed;

    [SerializeField]
    GameObject cameraX, cameraY, black;

    RaycastHit hit;

    bool scared = false;
    public bool lookingAtMonster;
    float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        black.SetActive(false);
        lookingAtMonster = false;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Translate(Vector3.forward * vInput * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * hInput * movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * mouseX * 200 * Time.deltaTime);

        cameraY.transform.Rotate(Vector3.left * mouseY * 200 * Time.deltaTime);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
        {
            if(hit.transform.tag == "Ghost")
            {
                lookingAtMonster=true;
            }
        }

        if(scared)
        {
            if(Time.deltaTime > timeStamp + 5)
            {
                Application.Quit();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ghost")
        {
            scared = false;
            timeStamp = Time.time;
            black.SetActive(true);
        }
    }
}
