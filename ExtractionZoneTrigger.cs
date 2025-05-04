using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using System.Collections;

public class ExtractionZoneTrigger : MonoBehaviour
{
    public float extractionTime = 3f;
    private bool playerInZone = false;
    private float timer = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            timer = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            timer = 0f;
        }
    }

    void Update()
    {
        if (playerInZone)
        {
            timer += Time.deltaTime;

            if (timer >= extractionTime)
            {
                // Successful extraction!
                ExtractPlayer();
            }
        }
    }

    void ExtractPlayer()
    {

        // Award currency
          if(ProgressionManager.Instance != null)
    {
        ProgressionManager.Instance.AddCurrency(100); // or scale based on loot
    }
        // Optional: Play feedbacks
        MMGameEvent.Trigger("ExtractionComplete");

        // Transition to next scene, show UI, etc.
        TopDownEngineEvent.Trigger(TopDownEngineEventTypes.LevelComplete);
    }
}
