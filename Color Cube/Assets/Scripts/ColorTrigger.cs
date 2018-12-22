using UnityEngine;
using UnityEngine.UI;

public class ColorTrigger : MonoBehaviour {

    /* This component is found on the players different color triggers.
     * It finds the child object blackened and enables that object when touching a 
     * black platform. It also disables the trigger.
     *
     * This changes the state of the players specific side from the color it had
     * to a blackened state, which disables further use of the color but gives the
     * player the ability to walk on black platforms.
     */

    private Transform blackened;
    private CapsuleCollider2D trigger;
    private Canvas c;
    private Animator blackScreen;

    void Start()
    {
        blackened = transform.Find("Blackened"); //Get child
        trigger = GetComponent<CapsuleCollider2D>(); // Get trigger

        blackScreen = FindObjectOfType<Canvas>().GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Black")) //If touching black platform
        {
            blackScreen.SetTrigger("Black");
            trigger.enabled = false;    // disable trigger
            blackened.gameObject.SetActive(true); //enable child object
        }
    }
}
