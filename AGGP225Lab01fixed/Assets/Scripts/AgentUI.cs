using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentUI : MonoBehaviour
{
    public Transform UIpos;
    public Vector2 UIvec;
    public RectTransform UIrect;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        UIrect = GetComponent <RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!UIpos)
        {
            return;
        }
        UIrect.position = RectTransformUtility.WorldToScreenPoint(cam, UIpos.position);
    }
}
