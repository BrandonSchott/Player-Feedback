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
    GameObject cameraX, cameraY, black, ghost, pauseMenu;

    RaycastHit hit;

    bool scared = false;
    float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        black.SetActive(false);
        pauseMenu.SetActive(false);
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

        if(Physics.Raycast(transform.position, transform.forward, out hit, 20.0f))
        {
            if(hit.transform.tag == "Ghost")
            {
                ghost.BroadcastMessage("PlayerLooking");
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
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
            Application.Quit();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
