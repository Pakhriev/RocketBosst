
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliionHandler : MonoBehaviour
{

    AudioSource audiosource;

    [SerializeField] AudioClip deathingpoint;
    [SerializeField] AudioClip succesPoint;
     [SerializeField] float levelLoadDelay = 2f;
    bool isTransioning  = false;
   void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) // taging object with reloadmethod;
    {
        if(isTransioning) { return; }
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
    // to do add SFX upon crash
    // to do add particle effect upon crush
    void StartSuccessSequence()
    {
        isTransioning = true;
        audiosource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke("_ReloadLevel", levelLoadDelay);
        audiosource.PlayOneShot(succesPoint);


    }
    // to do add SFX upon crash
    // to do add particle effect upon crush
    void StartCrashSequence()
    {
        isTransioning = true;
        audiosource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
        audiosource.PlayOneShot(deathingpoint);
        Start();
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
        if (nextSceneInded == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneInded = 0;
        }
        SceneManager.LoadScene(nextSceneInded);



    }

}