using UnityEngine;
using System.Collections;

public class FieldFade : MonoBehaviour
{

    public Vector3 startPos, startScale;
    public Vector3 endPos, endScale;
    public float initT;
    private float t;
    public float duration;

    // Use this for initialization
    void Start()
    {
        transform.localPosition = startPos;
        transform.localScale = startScale;
        t = initT;
    }

    public float GetFadeT()
    {
        return t;
    }

    void Render()
    {
        t += Time.fixedDeltaTime / duration;
        if (t >= 1)
            t = 0;
        transform.localPosition = Vector3.Lerp(startPos, endPos, t);
        if (t < 0.5f)
        {
            Vector3 foo = Vector3.Lerp(startScale, endScale, t);
            foo.y = startScale.y + (endScale.y - startScale.y) * t * 2;
            transform.localScale = foo;
        }
        else
        {
            Vector3 foo = Vector3.Lerp(startScale, endScale, t);
            foo.y = endScale.y + (startScale.y - endScale.y) * (t - 0.5f) * 2;
            transform.localScale = foo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Render();
    }
}
