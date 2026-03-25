using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIEnd : MonoBehaviour
{
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private TextMeshProUGUI _txtTotalTime;
    [SerializeField] private TextMeshProUGUI _txtCollisions;
    [SerializeField] private TextMeshProUGUI _txtFinal;

    private void Awake()
    {
        // Vérifie s'il y a un UIGame si oui on le détruit
        UIGame uiGame = FindAnyObjectByType<UIGame>();
        if(uiGame != null)
        {
            Destroy(uiGame.gameObject);
        }
    }

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(_buttonRestart.gameObject);
        _txtTotalTime.text = $"Temps total : {GameManager.Instance.EndTime:F2} sec.";
        _txtCollisions.text = $"Collisions : {GameManager.Instance.NbCollision}";
        float total = GameManager.Instance.NbCollision + GameManager.Instance.EndTime;
        _txtFinal.text = $"Temps final : {total:F2} sec.";
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();   // Quitte le programme exécutable
#endif
    }
}
