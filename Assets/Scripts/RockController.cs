using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RockController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private bool goalFound;
    Room1Door door;

    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<int>
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
        rb2d = GetComponent<Rigidbody2D>();
        goalFound = false;
        door = FindObjectOfType<Room1Door>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"rock collided with {collision.name}");
        if (collision.tag == "Player" && !goalFound)
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

        if (collision.tag == "RockGoal")
        {
            transform.position = collision.transform.position;
            rb2d.velocity = new Vector2(0, 0);
            goalFound = true;
            door._OnCompleteCallback(goalFound);
        }

        if (collision.tag == "Ground" || collision.tag == "Rock")
        {

            rb2d.velocity = new Vector2(0,0);

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
                break;

            case 1:
                rb2d.velocity = new Vector2(0, 10);
                break;

            case 2:
                rb2d.velocity = new Vector2(-10, 0);
                break;

            case 3:
                rb2d.velocity = new Vector2(10, 0);
                break;

            default: break;
        }
    }
}
