using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical).normalized * Speed * Time.deltaTime, Space.Self);
    }
}
