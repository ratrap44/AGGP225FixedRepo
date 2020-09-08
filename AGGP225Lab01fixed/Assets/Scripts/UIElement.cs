using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public AgentUI AgUI;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
       AgUI = GetComponent<AgentUI>();
       text = GetComponent<Text>();
    }

    public void tran(Transform target)
    {
        text.text = target.name;
        AgUI.UIpos = target.transform;
    }

}
