using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _playerMovementInput;
    private Vector2 _playerMouseInput;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCameras;
    [SerializeField] private float CameraSmoothSpeed = 10f;
    [SerializeField] private Vector3 CameraOffSet;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float JumpForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _playerMovementInput = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));

        MovePlayer();
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = PlayerBody.position + CameraOffSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, CameraSmoothSpeed * Time.deltaTime);
        PlayerCameras.position = smoothedPosition;
    }
    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(_playerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(moveVector.x, PlayerBody.velocity.y, moveVector.z);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }


}
