// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string lastExitScene;

    public PointsText points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current points data before changing the scene
            DataPersistenceManager.instance.SaveGame();

            PlayerPrefs.SetString("LastScene", lastExitScene);

            if (SceneManager.GetActiveScene().name != "1 - Lobby")
            {
                if (points.currentScenePoints >= 700)
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
            else
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
