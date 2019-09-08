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
        text.transform.position = new Vector3(1222, Screen.height - 100);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        int minutes = (int)timeLeft / 60;
        int seconds = (int)timeLeft - minutes * 60;

        text.text = $"Time left: {minutes}:{seconds}";

        text.transform.position = new Vector3(Screen.width - 100, Screen.height - 50);

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