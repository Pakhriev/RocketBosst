using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillator : MonoBehaviour
{
    Vector3 StartingPosition;
    [SerializeField ]Vector3 movementVector;
      float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
      
    }

    // Update is called once per frame
    void Update()

    {
        float cycle = Time.time / period;
        const float tau = Mathf.PI * 2;
        float wave = Mathf.Sin(cycle * tau);
        movementFactor = (wave + 1f) / 2;
        Vector3 offset = movementVector *movementFactor;
        transform.position = StartingPosition + offset;
        
    }
}
