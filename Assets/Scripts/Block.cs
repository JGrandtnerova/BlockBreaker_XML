using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    //premenna pri pridanie audia ktore sa prehra ak sa blok zrusi
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;

    //cached reference
    Level level;
    //state variables
    [SerializeField] int timesHit; //TODO only serialized for debug purpose

    [SerializeField] Sprite[] hitSprites;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
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
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array." + gameObject.name);
        }
    }

    private void DestroyBlock()
    { 
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        FindObjectOfType<GameStatus>().AddToScore();
        TriggerSparklesVFX(); //metoda ktora vytvori particle effect
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position,transform.rotation);
        //vytvori instanciu na urcenej pozicii s prislusnou rotaciou
        Destroy(sparkles, 1f);//sposobi znicenie instancie po 1 sekunde
    }

}
