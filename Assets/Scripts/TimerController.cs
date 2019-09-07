using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    private Text text;

    private bool timeOver;

    public float timeLeft;

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
        text = GetComponent<Text>();
        timeOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        int minutes = (int)timeLeft / 60;
        int seconds = (int)timeLeft - minutes * 60;

        text.text = $"Time left: {minutes}:{seconds}";

        if (timeLeft < 0 && !timeOver)
        {
            timeOver = true;
            _OnCompleteEvent.Invoke(true);
            
        }
    }

    private void _OnCompleteCallback(bool success)
    {

    }

}