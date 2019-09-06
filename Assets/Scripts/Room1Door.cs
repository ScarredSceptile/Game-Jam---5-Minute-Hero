using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Room1Door : MonoBehaviour
{

    public int Events;

    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {

    }

    [SerializeField]
    private BoolUnityEvent _OnCompleteEvent;

    private void Awake()
    {
        _OnCompleteEvent.AddListener(_OnCompleteCallback);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Events == 0)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _OnCompleteCallback(bool success)
    {
        Events--;
        if (Events == 0)
        {
            Destroy(gameObject);
        }
    }
}
