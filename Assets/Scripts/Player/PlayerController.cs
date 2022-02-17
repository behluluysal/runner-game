using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] private Transform PlayerCameras;
    [SerializeField] private float CameraSmoothSpeed = 10f;
    [SerializeField] private Vector3 CameraOffSet = new Vector3(0f,9f,-10f);
    [Space]
    [SerializeField] private float Speed = 5;
    [SerializeField] private float Sensitivity = 3;
    [SerializeField] private float JumpForce = 10;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState obj)
    {
        PlayerAnimator.Play("Running");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        PlayerCameras.position = transform.position + CameraOffSet;
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
