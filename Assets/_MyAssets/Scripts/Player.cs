using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static event EventHandler OnPlayerPaused;

    public static void TriggerOnPlayerPaused(object sender)
    {
        OnPlayerPaused?.Invoke(sender, EventArgs.Empty);
    }
    
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _playerRotationSpeed = 700f;

    private Animator _animator;
    private PlayerInputActions _playerInputActions;
    private Rigidbody _rb;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Dance.performed += Dance_performed;
        _playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerPaused?.Invoke(this, EventArgs.Empty);
    }

    private void Dance_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            _animator.SetBool("isDancing", true);
        }
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Dance.performed -= Dance_performed;
        _playerInputActions.Player.Disable();
        
    }

    private void FixedUpdate()
    {
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        // Old Input Manager
        // float directionX = Input.GetAxisRaw("Horizontal");
        // float directionZ = Input.GetAxisRaw("Vertical");

        // New Input Actions
        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();

        Vector3 direction = new Vector3(direction2D.x, 0f, direction2D.y);

        direction.Normalize();  // normalise la vecteur à 1

        // Déplacement (téléporation) dans la direction du vecteur
        // transform.Translate(direction * Time.deltaTime * _playerSpeed, Space.World);

        // Déplacement à une vitesse donné dans la direction du vecteur
        _rb.linearVelocity = direction * Time.fixedDeltaTime * _playerSpeed;
        
        // Pousser le corps dans la direction du vecteur
        //_rb.AddForce(direction * Time.fixedDeltaTime * _playerSpeed);

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation
                , toRotation, _playerRotationSpeed * Time.deltaTime);

            //Lance l'animation de marche
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                _animator.SetBool("isDancing", false);
            }
        }
    }

    public void DestroyPLayer()
    {
        Destroy(gameObject);
    }
}
