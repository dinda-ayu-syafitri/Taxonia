using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameComplete : MonoBehaviour, IDataPersistence
{

    [SerializeField] private int totalPoints = 0;

    private TextMeshProUGUI pointsText;

    private void Awake()
    {
        pointsText = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(GameData data)
    {
        this.totalPoints = data.totalPoints;
        print("Total Points: " + this.totalPoints);
    }

    public void SaveData(GameData data)
    {
        data.totalPoints = this.totalPoints;
    }
    // Update is called once per frame
    void Update()
    {
        pointsText.text = totalPoints.ToString();
    }
}
