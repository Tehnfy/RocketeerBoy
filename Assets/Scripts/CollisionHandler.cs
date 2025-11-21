using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Fren-shaped");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("Fuel Taken");
                break;
            default:
                ReloadLevel();
                break;
        }
        
        void ReloadLevel()
        {
            Debug.Log("crasherinoed");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }

        void LoadNextLevel()
        {
            Debug.Log("Finish achieved");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }
            
            SceneManager.LoadScene(nextScene);
        }

    }
}
