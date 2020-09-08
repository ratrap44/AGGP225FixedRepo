using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    public List<MoveTo> Commands;
    public GameObject TargetSphere;
    OnClick click;
    public int counter;
    public int cyclenum = 0;
    public bool directionswitch = true;
    public GameObject floatingUI;
    public Text info;
    public bool countbool;
    public int counterforward;
    //Variable that controls processing method
    // forward, backward, ping pong
    // could be an enum

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Commands = new List<MoveTo>();
    }

    void Update()
    {
        
        
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                Cycle();
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                StopandClear();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (cyclenum == 0)
                {
                  ProcessCommands();
                }
                if (cyclenum == 1)
                {
                  ProcessBackwards();
                }
                if ( cyclenum == 2)
                {
                  PingPong();
                }
            }
        Status();
    }

    public void AddMoveCommand(Vector3 Destination)
    {
        MoveTo MT = new MoveTo(agent);
        MT.DestinationPoint = Destination;
        Commands.Add(MT);
        Instantiate(TargetSphere, Destination, Quaternion.identity);
        Debug.Log("CMDlist count:" + Commands.Count);

    }
    public void Cycle()
    {
        if(cyclenum == 2)
        {
            cyclenum = 0;
        }
        else
        {
            cyclenum++;
        }
    }

    public void StopandClear()
    {
        Commands.Clear();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(obj);
        }
        Commands = new List<MoveTo>();
    }

    public void ProcessCommands()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (Commands.Count == 0)
            {
                return;
            }
            if (counterforward < Commands.Count)
            {
                Commands[counterforward].Execute(Commands[counterforward].DestinationPoint);
                counterforward++;
            }
        }

    }

    public void ProcessBackwards()
    {
    
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (Commands.Count == 0)
            {
                return;
            }
            if (countbool == false)
            {
                counter = Commands.Count - 1;
                Commands[counter].Execute(Commands[counter].DestinationPoint);
                countbool = true;
                return;
            }
            if (counter >= 0)
            {
                Commands[counter].Execute(Commands[counter].DestinationPoint);

            }
            else
            {
                counter = 0;
                countbool = false;
                return;
            }
        }
        counter--;
    }

    public void PingPong()
    {
        if (directionswitch == true)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (Commands.Count == 0)
                {
                    return;
                }
                if (counterforward < Commands.Count)
                {
                    Commands[counterforward].Execute(Commands[counterforward].DestinationPoint);
                    counterforward++;
                }
            }
            directionswitch = false;
        }
        if(directionswitch == false)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (Commands.Count == 0)
                {
                    return;
                }
                if (countbool == false)
                {
                    counter = Commands.Count - 1;
                    Commands[counter].Execute(Commands[counter].DestinationPoint);
                    countbool = true;
                    return;
                }
                if (counter >= 0)
                {
                    Commands[counter].Execute(Commands[counter].DestinationPoint);

                }
                else
                {
                    counter = 0;
                    countbool = false;
                    return;
                }
            }
            directionswitch = true;
            counter--;
        }
    }

    public void Status()
    {
        if(agent.isStopped == false)
        {
            if (cyclenum == 0)
            {
                info.text = "Forward";
            }
            if (cyclenum == 1)
            {
                info.text = "Backwards";
            }
            if(cyclenum == 2)
            {
                info.text = "Ping Pong";
            }
        }
        else
        {
            info.text = "Not Active";
        }
    }

}
