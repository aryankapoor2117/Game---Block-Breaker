using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //TODO for debug
    
    private void Start()
    {
       level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
        
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }
    public void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1; 
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit-1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array"+gameObject.name);

        }
    }
    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        FindObjectOfType<GameStatus>().AddToScore();
        level.BlockDestroyed();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }

}

