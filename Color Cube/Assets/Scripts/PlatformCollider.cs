
using UnityEngine;

public class PlatformCollider : MonoBehaviour {

    BoxCollider2D[] platformCollider;
    SpriteRenderer platformRenderer;
    bool match = false;
    public string platformColor;

    void Start()
    {
        platformCollider = GetComponents<BoxCollider2D>();
        platformRenderer = GetComponent<SpriteRenderer>();
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger ENTER activated!");
        Debug.Log("Triggering " + platformColor + " platform...");
        Debug.Log("Collider Tag = " + col.tag);

        if (!col.CompareTag("Player"))
        {
            Debug.Log("Not Player Collider");

            if (col.CompareTag(platformColor))
            {
                Debug.Log("Match = true");
                match = true;
            }
            else if (!match)
            {
                Debug.Log("Match = false");
                for (int i = 0; i < platformCollider.Length; i++)
                {
                    platformCollider[i].enabled = false;
                    Debug.Log("Platform Collider " + platformCollider[i].name + " disabled");
                }
                platformRenderer.enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Trigger EXIT activated!");

        Debug.Log("Triggering " + platformColor + " platform...");
        Debug.Log("Collider Tag = " + col.tag);

        if (col.CompareTag(platformColor))
        {
            Debug.Log("Setting match = false");
            match = false;
        }
    }
}
