using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
   [SerializeField] InputAction thrust;
   [SerializeField] float thrustStrenght=1000f;
   Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrust.Enable();
    }

    void FixedUpdate()
    {
        if(thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
        }
    }
}
