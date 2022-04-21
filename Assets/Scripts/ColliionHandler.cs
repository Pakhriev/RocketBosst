
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliionHandler : MonoBehaviour
{

    AudioSource audiosource;

    [SerializeField] AudioClip deathingpoint;
    [SerializeField] AudioClip succesPoint;
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
                Success();
                StartSuccessSequence();
                break;
            default:

                StartCrashSequence();
                death();
                break;
               
        }

    }
    // to do add SFX upon crash
    // to do add particle effect upon crush
    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("_ReloadLevel", levelLoadDelay);

    }
    // to do add SFX upon crash
    // to do add particle effect upon crush
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
    void death()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(deathingpoint);
    }
    void Success()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(succesPoint);
    }
   

}