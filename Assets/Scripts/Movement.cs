using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigitBody;
    AudioSource m_audiosource;
    bool isPlaying;
        

    [SerializeField] float mainTrust = 100f;
    [SerializeField] float rotateMoveSpeed = 5;
        
    // Start is called before the first frame update
    void Start()
    {
        rigitBody = GetComponent<Rigidbody>();
        m_audiosource = GetComponent<AudioSource>();
        isPlaying = m_audiosource.isPlaying;
       
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
            m_audiosource.Play();
        }
        else if (!isPlaying)
        {
            
            m_audiosource.Stop();

        }



        else if (Input.GetKey(KeyCode.S))
        {
            rigitBody.AddRelativeForce(Vector3.down * mainTrust * Time.deltaTime);
        }
       
    }
    void RotationMovement() //Keyboard movement
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateMoveSpeed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateMoveSpeed);
        }
        
        
    }
    public void ApplyRotation(float rotationThisFrame)//Rotation movement
    {
        rigitBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigitBody.freezeRotation = false;
        
    }
    
       
    
}
