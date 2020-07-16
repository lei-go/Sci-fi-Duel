using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas deathCanvas;

    void Start()
    {
        deathCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        deathCanvas.enabled = true;
        Time.timeScale = 0; //freeze the time
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
