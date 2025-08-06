using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goMainMenu : MonoBehaviour
{
    public GameObject menu;
    
    public AudioSource audioSource;
    
    private bool menuOn;
    
    // Start is called before the first frame update
    private void Start()
    {
        menuOn = false;
    }
    private void Update()
    {

        if (Input.GetButtonDown("Pause"))
        {
            if (!menuOn)
            {

                menu.SetActive(true);
                menuOn = true;
                Time.timeScale = 0;
                audioSource.Pause();
            }
            else if(menuOn)
            {
                menu.SetActive(false);
                menuOn = false;
                Time.timeScale = 1;
                audioSource.Play();
            }
        }
    }
    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("Main menu");
        menu.SetActive(false);
        
        Time.timeScale = 1;
        audioSource.Play();
    }
    public void resume()
    {
        menu.SetActive(false);
        menuOn = false ;
        
        Time.timeScale = 1;
        audioSource.Play();
    }
}


