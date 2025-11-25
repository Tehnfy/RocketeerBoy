using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotate;
    [SerializeField] float rotateSpeed = 122f;
    [SerializeField] float thrustSpeed = 12f;
    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem thustParticles;
    [SerializeField] ParticleSystem rightThustParticles;
    [SerializeField] ParticleSystem leftThustParticles;

    Rigidbody rb;
    AudioSource thrusterSound;
    void OnEnable()
    {
        thrust.Enable();
        rotate.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrusterSound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ControlThrust();
        ProcessRotation();
        ThrustParticles();
    }
    void Update()
    {
        if (thrust.IsPressed())
        {
            
            // Debug.Log("Space - pressed");
        }
    }
    void ControlThrust()
    {

        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed);
            if (!thrusterSound.isPlaying)
            {
                thrusterSound.PlayOneShot(engineSound);
            }
        }
        else
        {
            thrusterSound.Stop();
        }

    }

    private void ProcessRotation()
    {
        float rotationInput = rotate.ReadValue<float>();
        if (rotationInput < 0)
        {
            RotationSpeed(rotateSpeed);
            rightThustParticles.Play();
            leftThustParticles.Stop();

        }
        else if (rotationInput > 0)
        {
            RotationSpeed(-rotateSpeed);
            leftThustParticles.Play();
            rightThustParticles.Stop();
        }
    }

    private void RotationSpeed(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
    void ThrustParticles()
    {
        if (thrust.IsPressed())
        {
            thustParticles.Play();
        }
    }
}
