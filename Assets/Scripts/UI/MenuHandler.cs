using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject menu;
    private bool isMenuActive = false;
    private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
        
    }

    public void ToggleMenu()
    {
        isMenuActive = !isMenuActive;

        if (isMenuActive)
        {
            Time.timeScale = 0; 
            isGamePaused = true;
            menu.SetActive(true); 
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            isGamePaused = false;
            menu.SetActive(false); 
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
        }
    }

    public void OnDisable()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1; 
        }
    }
}
