
using UnityEngine;

public class PlatformCollider : MonoBehaviour {

    /* This script is on the platforms. It monitors any triggering event on the 
     * specific platform. If the players color trigger has the matching color the
     * platform stays enabled. If the color trigger doesn't match the platform color
     * the platform is disabled.
     * 
     * Sometimes the player collider seems to hit the platforms too, in these cases
     * nothing should be executed. Hence the first if statement.
     * 
     */

    bool match = false;
    public string platformColor;
    public AudioSource audioSource;

    void Start()
    {
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("ENTERING platform: " + platformColor+" with collider tag: "+col.tag);

        if (!col.CompareTag("Player"))
        {
            if (col.CompareTag(platformColor) || match)
            {
                Debug.Log("Match = true");
                match = true;
                audioSource.Play();
            }
            else
            {
                Debug.Log("Match = false");
                gameObject.SetActive(false);
                match = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("EXITING platform: " + platformColor + " with collider tag: " + col.tag);

        if (col.CompareTag(platformColor))
        {
            Debug.Log("Setting match = false");
            match = false;
        }
    }


    /*               The old way of disabling platform (if object still needs to be active for some reason)
     *               
     *                   BoxCollider2D[] platformCollider;
    SpriteRenderer platformRenderer;

     *               for (int i = 0; i < platformCollider.Length; i++)
                    {
                        platformCollider[i].enabled = false;
                        Debug.Log("Platform Collider " + platformCollider[i].name + " disabled");
                    }
                    platformRenderer.enabled = false;*/


}
