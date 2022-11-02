using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            player.SendMessage("ResumeGame");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        player.SendMessage("ResumeGame");
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    
}
