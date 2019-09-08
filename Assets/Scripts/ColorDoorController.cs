using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDoorController : MonoBehaviour
{

    public void ButtonPressed(string color)
    {
        if (color == transform.tag)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
