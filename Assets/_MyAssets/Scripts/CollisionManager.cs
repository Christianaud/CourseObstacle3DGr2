using UnityEngine;

public class CollisionManager : MonoBehaviour
{


    [SerializeField] private Material _hitMaterial = default(Material);
    [SerializeField] private int _collisionValue = 1;

    private bool _isHit = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !_isHit)
        {
            if (TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer))
            {
                meshRenderer.material = _hitMaterial;
            }
            else
            {
                MeshRenderer[] toto = GetComponentsInChildren<MeshRenderer>();
                foreach(var m in toto)
                {
                    m.material = _hitMaterial;
                }
            }
            
            

            //Augmenter le nombre de collision
            GameManager.Instance.AddCollision(_collisionValue);

            _isHit = true;
        }
        
    }
}
