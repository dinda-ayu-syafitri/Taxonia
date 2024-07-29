using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public void onNext()
    {
        Debug.Log("onNext called"); // Add this line
        SceneManager.LoadScene("18 - Outro Video");
        Debug.Log("Scene loaded"); // Add this line
    }

}
