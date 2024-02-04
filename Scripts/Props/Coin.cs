using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float amplitude = 1f; // Amplitude of the sin wave
    [SerializeField] float frequency = 1f; // Frequency of the sin wave
    [SerializeField] float speed = 1f; // Speed of rotation around its own axis
    public float chance=0.1f;

    private Vector3 initialPosition; // Initial position of the coin

    void Start()
    {
        // Store the initial position of the coin
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Calculate the new position of the coin using a sin wave pattern
        float yPos = initialPosition.y + amplitude * Mathf.Sin(Time.time * frequency);
        Vector3 newPosition = new Vector3(initialPosition.x, yPos, initialPosition.z);

        // Update the position of the coin
        transform.position = newPosition;

        // Rotate the coin around its own axis
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    public void PlaceObs(Vector3 pos,Transform parent)
    {
        Instantiate(this.gameObject,parent).transform.position=pos;
    }
}
