using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler :MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;
    public AudioSource clickSource;
    public AudioClip click;

    private int indexScene;


    public void Awake()
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    public void Update()
    {
        if (SceneManager.sceneCountInBuildSettings == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickSource.clip = click;
                clickSource.Play();
            }
        }
    }

    public void LoadPlay()
    {
        Time.timeScale = 1;
        indexScene = 1;
        SceneManager.LoadScene(indexScene);
    }
}
