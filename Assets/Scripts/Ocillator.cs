using UnityEngine;

public class Ocillator : MonoBehaviour
{
    private Vector3 _startingPosition;
    [SerializeField] Vector3 movementVector;
    float _movementFactor;
    [SerializeField] float period = 2f;
    [SerializeField] private float _offset = 1;
    private float movementMultiplier = .5f;

    private const float Tau = Mathf.PI * 2;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        var cycle = Time.time / period;
        var wave = Mathf.Sin(cycle * Tau);
        _movementFactor = (wave + _offset) * movementMultiplier;
        var offset = movementVector * _movementFactor;
        transform.position = _startingPosition + offset;
    }
}