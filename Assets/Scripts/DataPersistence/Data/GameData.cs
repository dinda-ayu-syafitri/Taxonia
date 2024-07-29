using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int totalPoints;
    public int emblemCollected;
    public int falseEmblemCollected;
    public int currentScenePoints;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> emblemItemCollected;
    public SerializableDictionary<string, bool> falseEmblemItemCollected;
    public SerializableDictionary<string, bool> powerUpUsed;
    public string currentScene;

    public GameData()
    {
        this.totalPoints = 0;
        this.emblemCollected = 0;
        this.playerPosition = new Vector3(14.5f, -7.51f, 1.26f);
        this.currentScene = "01 - Intro";
        this.emblemItemCollected = new SerializableDictionary<string, bool>();
        this.falseEmblemItemCollected = new SerializableDictionary<string, bool>();
        this.powerUpUsed = new SerializableDictionary<string, bool>();
        this.falseEmblemCollected = 0;
        this.currentScenePoints = 0;
    }

    public int GetPercentageCompleted()
    {
        switch (currentScene)
        {
            case "1 - Lobby":
                return 0;
            case "2 - Video Animalia":
                return 0;
            case "3 - Area Animalia":
                return 10;
            case "5 - Video Plantae":
                return 20;
            case "6 - Area Plantae":
                return 30;
            case "8 - Video Fungi":
                return 40;
            case "9 - Area Fungi":
                return 50;
            case "11 - Video Protista":
                return 60;
            case "12 - Area Protista":
                return 70;
            case "14 - Video Monera":
                return 80;
            case "15 - Area Monera":
                return 90;
            case "17 - Game Completed":
                return 100;
            case "18 - Outro Video":
                return 100;
            default:
                return 0;
        }
    }
}