
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    void OnCollisionEnter(Collision other) // taging object with reloadmethod;
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                print("good");
                break;
            case "Fuel":
                print("You picked up fuel");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:

                StartCrashSequence();
                break;
               
        }

    }
    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("_ReloadLevel", levelLoadDelay);

    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
    }
   
    void ReloadLevel() // reloadmethod with the build index
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

           
        SceneManager.LoadScene(currentSceneIndex);
    }
    void _ReloadLevel()
    {

        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneInded = _currentSceneIndex + 1;
        if(nextSceneInded == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneInded = 0;
        }
        SceneManager.LoadScene(nextSceneInded);

        
    }
        

}