using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsText : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int totalPoints = 0;

    private int emblemCollected = 0;

    private int falseEmblemCollected = 0;

    public int currentScenePoints = 0;

    private TextMeshProUGUI pointsText;

    private void Awake()
    {
        pointsText = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(GameData data)
    {
        this.totalPoints = data.totalPoints;
        this.emblemCollected = data.emblemCollected;
        this.falseEmblemCollected = data.falseEmblemCollected;
        this.currentScenePoints = data.currentScenePoints;
    }

    public void SaveData(GameData data)
    {
        data.totalPoints = this.totalPoints;
        data.emblemCollected = this.emblemCollected;
        data.falseEmblemCollected = this.falseEmblemCollected;
        data.currentScenePoints = this.currentScenePoints;
    }
    void Start()
    {
        GameEventManager.instance.onEmblemCollected += OnEmblemCollected;
        GameEventManager.instance.onFalseEmblemCollected += OnFalseEmblemCollected;
    }

    private void OnDestroy()
    {
        GameEventManager.instance.onEmblemCollected -= OnEmblemCollected;
        GameEventManager.instance.onFalseEmblemCollected -= OnFalseEmblemCollected;
    }

    private void OnEmblemCollected()
    {
        emblemCollected++;
        totalPoints += 100;
        currentScenePoints += 100;
        print(currentScenePoints);
    }
    private void OnFalseEmblemCollected()
    {
        falseEmblemCollected++;
        totalPoints -= 20;
        currentScenePoints -= 20;
        print(currentScenePoints);
    }
    void Update()
    {
        pointsText.text = totalPoints.ToString();
    }
}
