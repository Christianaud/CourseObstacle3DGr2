using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();   // Quitte le programme exécutable
#endif
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(0);
    }
}
