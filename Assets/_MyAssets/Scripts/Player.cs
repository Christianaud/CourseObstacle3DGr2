using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _playerRotationSpeed = 700f;
    
    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(directionX, 0f, directionZ);

        direction.Normalize();  // normalise la vecteur à 1

        transform.Translate(direction * Time.deltaTime * _playerSpeed, Space.World);

        if(direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation
                , toRotation, _playerRotationSpeed * Time.deltaTime);
        }

    }
}
