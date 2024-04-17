using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckContoller : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float backwardSpeed = 3f;
    [SerializeField] private float turnSpeed = 50f;
    [SerializeField] private AudioClip movingSound; 
    private AudioSource audioSource;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 

    }

    private void FixedUpdate()
    {
        // Get input for forward/backward movement
        float moveInput = Input.GetAxis("Vertical");

        // Get input for left/right steering
        float turnInput = Input.GetAxis("Horizontal");

        // Calculate speed based on input
        float speed = (moveInput >= 0f) ? forwardSpeed : backwardSpeed;

        // Move the vehicle forward or backward
        Vector3 movement = transform.forward * moveInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate the vehicle for steering
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);


        if (Mathf.Abs(moveInput) > 0.1f)
        {
            if (!audioSource.isPlaying && movingSound != null)
            {
                audioSource.PlayOneShot(movingSound);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}

