using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float gameDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    AudioSource audioSource;
    bool isTransitioning = false; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) return; 

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                SuccessLevel();
                break;
            default:
                CrashLevel();
                break;
        }
    }

    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

   void SuccessLevel()
{
    isTransitioning = true;
    if (success != null)
        audioSource.PlayOneShot(success);
    GetComponent<Movement>().enabled = false;
    Invoke("LoadNextLevel", gameDelay);
}

void CrashLevel()
{
    isTransitioning = true;
    if (crash != null)
        audioSource.PlayOneShot(crash);
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", gameDelay);
}
}


