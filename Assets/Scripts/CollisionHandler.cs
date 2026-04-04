using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            
            case "Finish":
            LoadNextLevel();
            break;
            default:
            ReloadLevel();
            break;
        }
    }
    void LoadNextLevel()
    {
         int currentScene=SceneManager.GetActiveScene().buildIndex;
         int nextScene=currentScene+1;

         if(nextScene==SceneManager.sceneCountInBuildSettings)
          {
            nextScene=0;
          }
         SceneManager.LoadScene(nextScene);
    }
    void ReloadLevel()
    {
        int currentScene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
