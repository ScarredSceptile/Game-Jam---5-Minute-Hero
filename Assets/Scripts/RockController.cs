using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RockController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private AudioSource sound;
    private bool goalFound;

    [System.Serializable]
    public class IntUnityEvent : UnityEvent<int>
    {

    }

    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {

    }

    [SerializeField]
    private IntUnityEvent _OnCompleteEvent;
    [SerializeField]
    private BoolUnityEvent _ObjectComplete;

    private void Awake()
    {
        _OnCompleteEvent.AddListener(_OnCompleteCallback);
        _ObjectComplete.AddListener(_OnCompleteObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        goalFound = false;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"rock collided with {collision.transform.name}");
        if (collision.gameObject.tag == "Player" && !goalFound)
        {

            if (collision.transform.position.x > transform.position.x)
            {
                if (Mathf.Abs(collision.transform.position.y - transform.position.y) > Mathf.Abs(collision.transform.position.x - transform.position.x))
                {
                    if (collision.transform.position.y > transform.position.y)
                    {
                        _OnCompleteCallback(0);
                    }
                    else
                    {
                        _OnCompleteCallback(1);
                    }
                }
                else
                {
                    _OnCompleteCallback(2);
                }
            }
            else
            {
                if (Mathf.Abs(collision.transform.position.y - transform.position.y) > Mathf.Abs(collision.transform.position.x - transform.position.x))
                {
                    if (collision.transform.position.y > transform.position.y)
                    {
                        _OnCompleteCallback(0);
                    }
                    else
                    {
                        _OnCompleteCallback(1);
                    }
                }
                else
                {
                    _OnCompleteCallback(3);
                }
            }
        }

        if (collision.gameObject.tag == "Rock")
        {

            rb2d.velocity = new Vector2(0, 0);
            sound.Stop();

            if (transform.position.x - (int)transform.position.x != 0.5)
            {
                if (transform.position.x - (int)transform.position.x >= 0)
                {
                    transform.position = new Vector3((int)transform.position.x + 0.5f, transform.position.y);
                }

                else if (transform.position.x - (int)transform.position.x < 0)
                {
                    transform.position = new Vector3((int)transform.position.x - 0.5f, transform.position.y);
                }
            }

            if (transform.position.y - (int)transform.position.y != 0.5)
            {
                if (transform.position.y - (int)transform.position.y < 0)
                {
                    transform.position = new Vector3(transform.position.x, (int)transform.position.y - 0.5f);
                }

                else if (transform.position.y - (int)transform.position.y >= 0)
                {
                    transform.position = new Vector3(transform.position.x, (int)transform.position.y + 0.5f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "RockGoal")
        {
            transform.position = collision.transform.position;
            rb2d.velocity = new Vector2(0, 0);
            sound.Stop();
            goalFound = true;
            _ObjectComplete.Invoke(true);
        }

        if (collision.tag == "Ground")
        {

            rb2d.velocity = new Vector2(0,0);
            sound.Stop();

            if (transform.position.x - (int)transform.position.x != 0.5)
            {
                if (transform.position.x - (int)transform.position.x >= 0)
                {
                    transform.position = new Vector3((int)transform.position.x + 0.5f, transform.position.y);
                }

                else if (transform.position.x - (int)transform.position.x < 0)
                {
                    transform.position = new Vector3((int)transform.position.x - 0.5f, transform.position.y);
                }
            }

            if (transform.position.y - (int)transform.position.y != 0.5)
            {
                if (transform.position.y - (int)transform.position.y < 0)
                {
                    transform.position = new Vector3(transform.position.x, (int)transform.position.y - 0.5f);
                }

                else if (transform.position.y - (int)transform.position.y >= 0)
                {
                    transform.position = new Vector3(transform.position.x, (int)transform.position.y + 0.5f);
                }
            }
        }
    }

    private void _OnCompleteCallback(int side)
    {
        // 0 = downPush 1 = upPush 2 = leftPush 3 = rightPush
        switch (side)
        {
            case 0:
                rb2d.velocity = new Vector2(0,-10);
                sound.Play();
                break;

            case 1:
                rb2d.velocity = new Vector2(0, 10);
                sound.Play();
                break;

            case 2:
                rb2d.velocity = new Vector2(-10, 0);
                sound.Play();
                break;

            case 3:
                rb2d.velocity = new Vector2(10, 0);
                sound.Play();
                break;

            default: break;
        }
    }

    private void _OnCompleteObject (bool success)
    {

    }
}
