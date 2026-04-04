using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
   [SerializeField] InputAction thrust;
   [SerializeField] InputAction rotation;
   [SerializeField] float thrustStrenght=1000f;
   [SerializeField] float rotationStrenght=100f;
   Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
        }
    }

    void ProcessRotation()
    {
        float rotationInput=rotation.ReadValue<float>();
        if(rotationInput<0)
        {
            ApplyRotation(rotationStrenght);
        }
        else if(rotationInput>0)
        {
           ApplyRotation(-rotationStrenght);
        }
    }

    private void ApplyRotation(float rotationFrame)
    {
        transform.Rotate(Vector3.forward * rotationFrame * Time.fixedDeltaTime);
    }
}
