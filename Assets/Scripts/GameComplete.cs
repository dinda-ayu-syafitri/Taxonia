using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public void onNext()
    {
        SceneManager.LoadScene("18 - Outro Video");
    }

}
