using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FalseEmblem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();

    }

    bool collected = false;

    private TextMeshPro organismText;
    public string organismName;

        private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    public Sprite emblemImage; // Image to be assigned to SpriteRenderer

 private void Awake()
    {
        organismText = GetComponentInChildren<TextMeshPro>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {

        if (organismText != null)
        {
            organismText.text = organismName;
        }
       

        if (spriteRenderer != null && emblemImage != null)
        {
            spriteRenderer.sprite = emblemImage;
        }
      
    }

    public void LoadData(GameData gameData)
    {
        gameData.falseEmblemItemCollected.TryGetValue(id, out collected);
        if (collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(GameData gameData)
    {
        if (gameData.falseEmblemItemCollected.ContainsKey(id))
        {
            gameData.falseEmblemItemCollected.Remove(id);
        }
        gameData.falseEmblemItemCollected.Add(id, collected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected)
        {
            CollectFalseEmblem();
        }
    }

    private void CollectFalseEmblem()
    {
        collected = true;
        Destroy(gameObject);
        GameEventManager.instance.FalseEmblemCollected();
    }
}
