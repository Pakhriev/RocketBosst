using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigitBody;
    AudioSource m_audiosource;
   

        

    [SerializeField] float mainTrust = 1f;
    [SerializeField] float rotateMoveSpeed = 5;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem Thrusting;
    [SerializeField] ParticleSystem leftThrusting;
    [SerializeField] ParticleSystem RightThrusting;
        
    // Start is called before the first frame update
    void Start()
    {
        rigitBody = GetComponent<Rigidbody>();
        m_audiosource = GetComponent<AudioSource>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        RotationMovement();
        ProcessThurst();
    }
    void ProcessThurst()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigitBody.AddRelativeForce(Vector3.up * mainTrust * Time.deltaTime);

            if (!m_audiosource.isPlaying)
                if (!m_audiosource.isPlaying)
                {
                    m_audiosource.PlayOneShot(mainEngine);
                }
            if (!Thrusting.isPlaying)
            {
                Thrusting.Play();
            }
        }

        else
        {
            m_audiosource.Stop();
            Thrusting.Stop();

        }

        }


       
       
    
    void RotationMovement() //Keyboard movement
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateMoveSpeed);
            leftThrusting.Play();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateMoveSpeed);
            RightThrusting.Play();
        }
        
        
    }
    public void ApplyRotation(float rotationThisFrame)//Rotation movement
    {
        rigitBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigitBody.freezeRotation = false;
        
    }
    
       
    
}
