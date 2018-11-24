using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public GameObject position1;
    public GameObject position2;
    public float step = 1;
    public float defaultOffset = 5;
    private bool movingForward = true;

    // Use this for initialization
    void Start () {
        if (position1 == null)
        {
            position1 = new GameObject();
            position1.transform.position = transform.position + new Vector3(-defaultOffset, 0, 0);
        }
        if (position2 == null)
        {
            position2 = new GameObject();
            position2.transform.position = transform.position + new Vector3(defaultOffset, 0, 0);
        }
    }

    // Update is called once per frame
    void Update () {
        if (movingForward)
            transform.position += new Vector3(step, 0, 0);

        if (!movingForward)
            transform.position -= new Vector3(step, 0, 0);

        if (transform.position.x >= position2.transform.position.x) movingForward = false;
        if (transform.position.x <= position1.transform.position.x) movingForward = true;

    }
}
