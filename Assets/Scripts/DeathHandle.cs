using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandle : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Awake()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0f; //stops time
        Cursor.lockState = CursorLockMode.None; // enabled the curor from being locked in movement
        Cursor.visible = true;
    }




}
