using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction turn;
    [SerializeField] 

    Rigidbody rb;



    void OnEnable()
    {
        thrust.Enable();
        turn.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up*10);
        }
    }
    void Update()
    {
        if (thrust.IsPressed())
        {
           // Debug.Log("Space - pressed");
        }

        if (turn.IsPressed())
        {
            Debug.Log("turn - pressed");
        }
    }
}
