using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* Classe qui définit un singleton */

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int _nbCollisions;
    public int NbCollision => _nbCollisions; // accesseur public

    private void Start()
    {
        _nbCollisions = 0;
    }

    public void AddCollision(int p_value)
    {
        _nbCollisions += p_value;
        // Debug.Log("Nombre de collision(s) : " + _nbCollisions);
    }
}
