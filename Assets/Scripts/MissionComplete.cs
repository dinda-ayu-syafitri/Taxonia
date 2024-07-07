using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MissionComplete : MonoBehaviour
{
    public string nextScene;
    public TextMeshProUGUI medalNameObject;
    public string medalName;
    public Image medalImage;
    public Sprite medalImageSprite;

    // Start is called before the first frame update

    public void OnNextClicked()
    {
        SceneManager.LoadScene(nextScene);
    }

    void Start()
    {
        medalImage.sprite = medalImageSprite;
        medalNameObject.text = medalName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
