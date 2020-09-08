using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.AI;

public class MoveTo : CommandBase
{
    public Vector3 DestinationPoint;
    public Vector3 StartingPoint;
    public NavMeshAgent agent;


        public MoveTo( NavMeshAgent steve)
        {
            this.agent = steve;
        }

    public override void Execute(Vector3 Destination)
    {
        agent.destination = DestinationPoint;

    }

}
