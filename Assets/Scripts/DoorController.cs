using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DoorController : MonoBehaviour
{

    public int Events;

    // Start is called before the first frame update
    void Start()
    {
        if (Events == 0)
        {
            Destroy(this);
        }
    }

    public void goalUpdate()
    {
        Events--;
        if (Events == 0)
        {
            Destroy(gameObject);
        }
    }
}
