using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    [Header("Score")]
    public Text Score1;
    public Text Score2;

    public float score;

    [Header("Audio")]
    public AudioSource shootSource;
    public AudioClip shootClip;

    public bool isDead = false;

    public static GameManger instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        Score1.text = "Ships fixed: " + score;
        Score2.text = "Ships fixed: " + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
