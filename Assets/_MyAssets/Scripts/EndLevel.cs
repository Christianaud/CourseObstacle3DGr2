using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            int noScene = SceneManager.GetActiveScene().buildIndex;

            //Vérifier si dernière scène de jeu
            if (noScene < SceneManager.sceneCountInBuildSettings - 2)
            {
                //Passer à la scène suivante
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                GameManager.Instance.EndTime = Time.time - GameManager.Instance.StartTime;
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
