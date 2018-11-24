using UnityEngine;

public class ColorTrigger : MonoBehaviour {

    private Transform blackened;
    private CapsuleCollider2D trigger;

    void Start()
    {
        blackened = transform.Find("Blackened");
        trigger = GetComponent<CapsuleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Black"))
        {
            trigger.enabled = false;
            blackened.gameObject.SetActive(true);
        }
    }
}
