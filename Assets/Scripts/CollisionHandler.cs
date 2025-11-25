using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip crashSound;
    [SerializeField] ParticleSystem winParticles;
    [SerializeField] ParticleSystem crashParticles;

  

    AudioSource audioSource;
    bool isControllable = true;
    bool isCollidable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }
    void OnCollisionEnter(Collision other)
    {
        if(!isControllable || !isCollidable)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Fren-shaped");
                break;
            case "Finish":
                StartSuccessSequence();                
                break;
            case "Fuel":
                Debug.Log("Fuel Taken");
                break;
            default:
                StartCrashSequence();
                break;
        }

    }

    private void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.PlayOneShot(winSound);
        winParticles.Play(winParticles);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
        
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.PlayOneShot(crashSound);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
        return;
    }

    void ReloadLevel()
    {
            isControllable = false;
        Debug.Log("crasherinoed");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
            return;
        }

    void LoadNextLevel()
    {
        isControllable = false;
        Debug.Log("Finish achieved");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
    void Update()
    {
        RespondToDebugKeys();
    }
        void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.isPressed)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
            Debug.Log("Collissions Toggled");
        }
    }
}
