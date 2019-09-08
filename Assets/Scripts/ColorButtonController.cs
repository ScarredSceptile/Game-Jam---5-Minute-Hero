using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ColorButtonController : MonoBehaviour
{
    public string Color;
    public AudioSource sound;

    [System.Serializable]
    public class StringUnityEvent : UnityEvent<string>
    {

    }

    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {

    }

    [SerializeField]
    private StringUnityEvent _onCompleteEvent;
    [SerializeField]
    private BoolUnityEvent _OnGoldTrigger;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ensure that it is the player it collides with
        if (collision.tag == "Player")
        {
            sound.Play();

            if (Color != "Gold")
            {
                _onCompleteEvent.Invoke(Color);
            }
            else
            {
                _OnGoldTrigger.Invoke(true);
                gameObject.SetActive(false);
            }
        }
    }
}
