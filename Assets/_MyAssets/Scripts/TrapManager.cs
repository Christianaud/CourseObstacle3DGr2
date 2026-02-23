using UnityEngine;
using System.Collections.Generic;

public class TrapManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listeTraps = new List<GameObject>();
    [SerializeField] private float _forceIntensity = 100f;

    [SerializeField] Vector3 _direction = Vector3.down;

    private List<Rigidbody> _listeRbs = new List<Rigidbody>();
    private bool _isTriggered = false;

    private void Start()
    {
        foreach(var r in _listeTraps)
        {
            _listeRbs.Add(r.GetComponent<Rigidbody>());
            r.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_isTriggered && other.CompareTag("Player"))
        {
            foreach(var r in _listeRbs)
            {
                r.useGravity = true;
                r.AddForce(_direction * _forceIntensity);
            }
            
            _isTriggered = true;
        }
    }
}
