using UnityEngine;
using System.Collections;

public class RedButtonScript : MonoBehaviour
{

    public Vector3 PressedPosition;
    public Vector3 ReleasedPosition;

    private bool pressed;

    public void DoActivateTrigger()
    {
        if (!pressed)
        {
            StartCoroutine(Press());
        }
        else
        {
            StartCoroutine(Release());
        }
    }

    public IEnumerator Press()
    {
        if (!pressed)
        {
            while (transform.position != PressedPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, PressedPosition, 0.1f);
                if (Vector3.Distance(transform.position, PressedPosition) <= 0.1f)
                {
                    transform.position = PressedPosition;
                    pressed = true;
                }
                yield return null;
            }
        }
    }

    public IEnumerator Release()
    {
        if (pressed)
        {
            while (transform.position != ReleasedPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, ReleasedPosition, 0.1f);
                if (Vector3.Distance(transform.position, ReleasedPosition) <= 0.1f)
                {
                    transform.position = ReleasedPosition;
                    pressed = false;
                }
                yield return null;
            }
        }
    }

    public bool IsPressed()
    {
        return pressed;
    }
}