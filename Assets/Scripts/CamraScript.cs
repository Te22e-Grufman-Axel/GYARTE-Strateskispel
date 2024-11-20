using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float Hasithet = 10f;
    public float Roteringfart = 50f;
    public float Roteringområde = 50f;
    private Vector3 riktining;
    public float ZoomSpeed = 25f;
    public float Maxzoom = 100f;
    public float MinZoom = 55f;
    public float wheelmovment;


    void Update()
    {
        Movement();
        EdgeRotation();
        Zoom();
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
    }



    void EdgeRotation()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (mousePosition.x <= Roteringområde || Input.GetKey(KeyCode.Q))
        {
            RotateCamera(Vector3.down);
        }
        else if (mousePosition.x >= Screen.width - Roteringområde || Input.GetKey(KeyCode.E))
        {
            RotateCamera(Vector3.up);
        }
    }
    void RotateCamera(Vector3 rotationDirection)
    {
        transform.Rotate(rotationDirection * Roteringfart * Time.deltaTime, Space.World);
    }


    void Zoom()
    {
        wheelmovment = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(wheelmovment) > 0)
        {
            float zoomAmount = wheelmovment * ZoomSpeed * Time.deltaTime;
            Vector3 zoomDirection = transform.forward;
            Vector3 targetPosition = transform.position + zoomDirection * zoomAmount;
            float newHeight = targetPosition.y;
            if (newHeight < MinZoom)
            {
                targetPosition.y = MinZoom;
            }
            else if (newHeight > Maxzoom)
            {
                targetPosition.y = Maxzoom;
            }
            transform.position = targetPosition;
        }
    }




}
