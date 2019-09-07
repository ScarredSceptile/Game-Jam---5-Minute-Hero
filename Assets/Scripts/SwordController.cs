using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwordController : MonoBehaviour
{
    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {

    }

    [SerializeField]
    private BoolUnityEvent _OnCompletedEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _OnCompletedEvent.Invoke(true);
            gameObject.SetActive(false);
        }
    }
}
