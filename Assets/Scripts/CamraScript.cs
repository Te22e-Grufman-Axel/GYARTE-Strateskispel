using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Hasithet = 10f;
    public float Roteringfart = 50f;
    public float Roteringområde = 50f;
    private Vector3 riktining;


    void Update()
    {
        Movement();
        EdgeRotation();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forwardMovement = transform.forward * vertical;
        Vector3 rightMovement = transform.right * horizontal;
        Vector3 movement = (forwardMovement + rightMovement).normalized;

        movement.y = 0;
        transform.position += movement * Hasithet * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 50f, transform.position.z);
    }


    void EdgeRotation()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (mousePosition.x <= Roteringområde)
        {
            RotateCamera(Vector3.down);
        }
        else if (mousePosition.x >= Screen.width - Roteringområde)
        {
            RotateCamera(Vector3.up);
        }
    }
       void RotateCamera(Vector3 rotationDirection)
    {
        transform.Rotate(rotationDirection * Roteringfart * Time.deltaTime, Space.World);
    }

}
