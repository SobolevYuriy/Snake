using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public SnakeMovement SnakeMovement;

    public GameObject LoseDisplay;
    public GameObject PauseDisplay;

    [SerializeField] private string _sceneName;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        OnPlayerPlay();
    }

    public enum Status
    {
        Playing,
        Pause,
        Exit,
        Lose,
    }

    public Status CurrentStatus { get; private set; }

    public void OnPlayerPlay()
    {
        if (CurrentStatus != Status.Playing) return;
        audioManager.Play("SnakeAudio");
    }

    public void OnPlayerDied()
    {
        if (CurrentStatus != Status.Playing) return;
        CurrentStatus = Status.Lose;
        SnakeMovement.enabled = false;
        Time.timeScale = 0f;
        LoseDisplay.SetActive(true);
        audioManager.SoundStop("SnakeAudio");
        audioManager.Play("SnakeDead");
    }

    public void OnPlayerPause()
    {
        if (CurrentStatus != Status.Playing) return;
        CurrentStatus = Status.Pause;
        SnakeMovement.enabled = false;
        Time.timeScale = 0f;
        audioManager.SoundStop("SnakeAudio");
        PauseDisplay.SetActive(true);
    }

    public void OnPlayerRestart()
    {
        if (CurrentStatus != Status.Pause) return;
        CurrentStatus = Status.Playing;
        SnakeMovement.enabled = true;
        Time.timeScale = 1f;
        audioManager.Play("SnakeAudio");
        PauseDisplay.SetActive(false);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SnakeMovement.enabled = true;
        Time.timeScale = 1f;
    }

    public void OnPlayerExit()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
