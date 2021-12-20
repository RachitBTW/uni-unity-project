using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameObject PauseMenu;

    void Update()
    {

        if (PauseMenu.activeSelf.Equals(false))
        {
            Time.timeScale = 1;
        }

        PauseGame();
    }

    void PauseGame()
    {
        if (PauseMenu.activeSelf.Equals(false) && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0.01f;
            Debug.Log("Activated");
        }
        else if (PauseMenu.activeSelf.Equals(true) && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(false);
            Debug.Log("Deactivated");
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
    }
}
