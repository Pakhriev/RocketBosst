using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigitBody;
    private AudioSource _mAudiosource;

    [SerializeField] float mainTrust = 1f;
    [SerializeField] float rotateMoveSpeed = 5;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem Thrusting;
    [SerializeField] ParticleSystem leftThrusting;

    [FormerlySerializedAs("RightThrusting")] [SerializeField]
    ParticleSystem rightThrusting;
    
    
    private void Start()
    {
        _rigitBody = GetComponent<Rigidbody>();
        _mAudiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RotationMovement();
        ProcessThurst();
    }

    private void ProcessThurst()
    {
        if (Input.GetKey(KeyCode.Space))
            StartThrusting();
        else
            StopThrusting();
    }

    private void StartThrusting()
    {
        _rigitBody.AddRelativeForce(Vector3.up * mainTrust * Time.deltaTime);

        if (!_mAudiosource.isPlaying)
            if (!_mAudiosource.isPlaying)
                _mAudiosource.PlayOneShot(mainEngine);

        if (!Thrusting.isPlaying)
            Thrusting.Play();
    }

    private void StopThrusting()
    {
        _mAudiosource.Stop();
        Thrusting.Stop();
    }


    void RotationMovement() //Keyboard movement
    {
        var direct = -Input.GetAxis("Horizontal"); // -1 to 1

        ApplyRotation(rotateMoveSpeed * direct);

        switch (direct)
        {
            case > 0 when !leftThrusting.isPlaying:
                leftThrusting.Play();
                break;
            case < 0 when !rightThrusting.isPlaying:
                rightThrusting.Play();
                break;
            default:
                leftThrusting.Stop();
                rightThrusting.Stop();
                break;
        }
    }


    public void ApplyRotation(float rotationThisFrame) //Rotation movement
    {
        _rigitBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigitBody.freezeRotation = false;
    }
}