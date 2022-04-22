
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ColliionHandler : MonoBehaviour
{

    AudioSource audiosource;
    ParticleSystem particleSystem;

    [SerializeField] AudioClip deathingpoint;
    [SerializeField] AudioClip succesPoint;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] float levelLoadDelay = 2f;
    
    bool isTransioning  = false;
    bool oncollisionDisabled = false;
   void Start()
    {
        audiosource = GetComponent<AudioSource>();
         particleSystem = GetComponent<ParticleSystem>();
    }
  void Update()
    {
        reloadlevelbyKey();
    }
    void OnCollisionEnter(Collision other) // taging object with reloadmethod;
    {
        if(isTransioning) { return; }
        if (isTransioning || oncollisionDisabled ) { return; }
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
        successParticles.Play();


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
        crashParticles.Play();
       
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
    void reloadlevelbyKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _ReloadLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            oncollisionDisabled = !oncollisionDisabled;
        }
    }
    
   

}