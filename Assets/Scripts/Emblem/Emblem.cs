using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Emblem : MonoBehaviour, IDataPersistence
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

    private SpriteRenderer spriteRenderer;
    public Sprite emblemImage;


    public AudioSource audioSource;

    public AudioClip musicClip;

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
        gameData.emblemItemCollected.TryGetValue(id, out collected);
        if (collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(GameData gameData)
    {
        if (gameData.emblemItemCollected.ContainsKey(id))
        {
            gameData.emblemItemCollected.Remove(id);
        }
        gameData.emblemItemCollected.Add(id, collected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected)
        {
            CollectEmblem();
        }
    }

    private void CollectEmblem()
    {
        collected = true;
        GameEventManager.instance.EmblemCollected();
        transform.position = Vector3.one * 9999f;
        PlayMusic();
        StartCoroutine(WaitForMusicToEnd());
    }

    public void PlayMusic()
    {
        if (audioSource.clip != musicClip)
        {
            audioSource.clip = musicClip;
        }
        audioSource.Play();
    }

    private IEnumerator WaitForMusicToEnd()
    {
        yield return new WaitForSeconds(musicClip.length);
        Destroy(gameObject);
    }

}
