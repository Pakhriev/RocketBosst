
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliionHandler : MonoBehaviour
{
    Rigidbody Rigidbody;
   

    void OnCollisionEnter(Collision other) // taging object with reloadmethod;
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("game started");
                break;
            case "Fuel":
                print("You picked up fuel");
                break;
            case "Finish":
                Invoke("_ReloadLevel",0.5f);
                break;
            default:

                Invoke("StartCrashSequence",1f);  
                break;
               
        }

    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;

        ReloadLevel();
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