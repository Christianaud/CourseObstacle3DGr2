using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _playerRotationSpeed = 700f;

    private Animator _animator;
    private PlayerInputActions _playerInputActions;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }

    private void Update()
    {
        // Old Input Manager
        // float directionX = Input.GetAxisRaw("Horizontal");
        // float directionZ = Input.GetAxisRaw("Vertical");

        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();
        
        Vector3 direction = new Vector3(direction2D.x, 0f, direction2D.y);

        direction.Normalize();  // normalise la vecteur à 1

        transform.Translate(direction * Time.deltaTime * _playerSpeed, Space.World);

        if(direction != Vector3.zero)
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
        }

    }
}
