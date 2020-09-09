using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public Camera maincam;
    public Agent agent;
    public MoveTo move;
    void Start()
    {
        maincam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Position();
        }

    }

    public void Position()
    {
        RaycastHit hit;
        Ray ray = maincam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform target = hit.transform;

            agent.AddMoveCommand(hit.point);

            if (hit.collider.name == "floor")
            {
                if (agent.Commandlist.Count == 0)
                {
                    move.StartingPoint = Vector3.zero;
                    move.DestinationPoint = hit.transform.position;
                }
                else
                {
                    
                    agent.AddMoveCommand(hit.point);
                    move.DestinationPoint = hit.transform.position;
                }
            }
        }

    }
}