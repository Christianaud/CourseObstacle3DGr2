using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject.CompareTag("Player"))
        {
            int noScene = SceneManager.GetActiveScene().buildIndex;

            //Vérifier si dernière scène
            if (noScene < SceneManager.sceneCountInBuildSettings - 1)
            {
                // Récupérer la scène en cours
                string nomScene = SceneManager.GetActiveScene().name;

                //Passer à la scène suivante
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                Debug.Log("-------------- Fin de partie -----------------");
                Debug.Log("Nombre total de collisions : " + GameManager.Instance.NbCollision);
                Debug.Log("Temps total : " + Time.time.ToString("f2") +  " secondes");
                Debug.Log("Temps avec collisions : " + 
                    (GameManager.Instance.NbCollision + Time.time).ToString("f2") + " secondes");
                Player player = FindAnyObjectByType<Player>();
                player.DestroyPLayer();
            }
               
            

        }
    }
}
