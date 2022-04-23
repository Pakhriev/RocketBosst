using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;

public class CollisionHandler : MonoBehaviour
{
    private AudioSource _audiosource;
    private Movement _movement;


    [SerializeField] private AudioClip deathingpoint;
    [SerializeField] private AudioClip succesPoint;
    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem crashParticles;
    [SerializeField] private float levelLoadDelay = 2f;

    private bool _isTransioning = false;
    private bool _oncollisionDisabled = false;

    private void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        ReloadlevelbyKey();
    }

    private void OnCollisionEnter(Collision other) // taging object with reloadmethod;
    {
        if (_isTransioning || _oncollisionDisabled)
            return;

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
    private async void StartSuccessSequence()
    {
        _isTransioning = true;
        _audiosource.Stop();
        _movement.enabled = false;
        _audiosource.PlayOneShot(succesPoint);
        successParticles.Play();

        await Task.Delay(TimeSpan.FromSeconds(levelLoadDelay));
        SuccessReloadLevel();
    }

    // to do add SFX upon crash
    // to do add particle effect upon crush
    private async void StartCrashSequence()
    {
        _isTransioning = true;
        _audiosource.Stop();
        _movement.enabled = false;
        _audiosource.PlayOneShot(deathingpoint);
        Start();
        crashParticles.Play();

        await Task.Delay(TimeSpan.FromSeconds(levelLoadDelay));
        FailureReloadLevel();
    }

    private void FailureReloadLevel() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reloadmethod with the build index

    private void SuccessReloadLevel() =>
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);


    // 10 % 5 = 0
    // 12 % 5 = 2 // ceil
    // 14 % 5 = 4
    // 15 % 5 = 0


    // 4 % 6 = 4
    // 5 % 6 = 5 // last level
    // 6 % 6 = 0 


    private void ReloadlevelbyKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SuccessReloadLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _oncollisionDisabled = !_oncollisionDisabled;
        }
    }
}