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
                if (agent.Commands.Count == 0)
                {
                    move.StartingPoint = Vector3.zero;
                    move.DestinationPoint = hit.transform.position;
                }
                else
                {
                    move.StartingPoint = agent.Commands[agent.Commands.Count - 1].DestinationPoint;
                    move.DestinationPoint = hit.transform.position;
                }
            }
        }

    }

   
}
