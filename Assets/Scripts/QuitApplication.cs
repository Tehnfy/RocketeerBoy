using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        QuitApp();
    }
    void QuitApp()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
        Application.Quit();
        }
    }
}
