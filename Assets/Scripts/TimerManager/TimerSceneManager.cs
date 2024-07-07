using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSceneManager : MonoBehaviour
{
    public GameObject restartModal;
    private PlayerController playerController;

    void Start()
    {
        if (TimerManager.instance != null)
        {
            TimerManager.instance.onTimeUp += showRestartModal; 
        }
        else
        {
            Debug.LogError("TimerManager instance is null.");
        }

        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        if (TimerManager.instance != null)
        {
            TimerManager.instance.onTimeUp -= showRestartModal; 
        }
    }

    void showRestartModal()
    {
        if (playerController != null)
        {
            playerController.FreezePlayer(); 
        }

        restartModal.gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        playerController.canMove = true;
    }
}
