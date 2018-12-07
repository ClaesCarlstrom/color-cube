using UnityEngine;

public class ColorTrigger : MonoBehaviour {

    /* This component is on the players different color triggers.
     * It finds the child object blackened and enables that object when touching a 
     * black platform. It also disables the trigger.
     *
     * This changes the state of the players specific side from the color it had
     * to a blackened state, which disables further use of the color but gives the
     * player the ability to walk on black platforms.
     */

    private Transform blackened;
    private CapsuleCollider2D trigger;

    void Start()
    {
        blackened = transform.Find("Blackened"); //Get child
        trigger = GetComponent<CapsuleCollider2D>(); // Get trigger
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Black")) //If touching black platform
        {
            trigger.enabled = false;    // disable trigger
            blackened.gameObject.SetActive(true); //enable child object
        }
    }
}
