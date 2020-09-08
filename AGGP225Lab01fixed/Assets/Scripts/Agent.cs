using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    public List<CommandBase> Commandlist;
    public GameObject TargetSphere;


    public int cyclenum = 0;
    public bool directionswitch = true;
    public GameObject floatingUI;
    public Text info;
    public bool countbool;

    public int commandindex;
    //Variable that controls processing method
    // forward, backward, ping pong
    // could be an enum

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Commandlist = new List<CommandBase>();
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
            if (cyclenum == 2)
            {
                PingPong();
            }
        }
        UIStatus();

    }

    public void AddMoveCommand(Vector3 Destination)
    {
        MoveTo MT = new MoveTo(agent);
        MT.DestinationPoint = Destination;
        Commandlist.Add(MT);
        Instantiate(TargetSphere, Destination, Quaternion.identity);
        Debug.Log("CMDlist count:" + Commandlist.Count);

    }
    public void Cycle()
    {
        if (cyclenum == 2)
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
        Commandlist.Clear();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(obj);
        }
        //Commands = new List<MoveTo>();
    }

    public void ProcessCommands()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (Commandlist.Count == 0)
            {
                return;
            }
            if (commandindex < Commandlist.Count)
            {
                Commandlist[commandindex].Execute();
                commandindex++;
            }
        }

    }

    public void ProcessBackwards()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (Commandlist.Count == 0)
            {
                return;
            }
            if (countbool == false)
            {
                commandindex = Commandlist.Count - 1;
                Commandlist[commandindex].Execute();
                countbool = true;
                return;
            }
            if (commandindex >= 0)
            {
                Commandlist[commandindex].Execute();

            }
            else
            {
                commandindex = 0;
                countbool = false;
                return;
            }
        }
        commandindex--;
    }

    public void PingPong()
    {
        if (directionswitch == true)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (Commandlist.Count == 0)
                {
                    return;
                }
                if (commandindex < Commandlist.Count)
                {
                    Commandlist[commandindex].Execute();
                    commandindex++;
                }
            }
            directionswitch = false;
        }
        if (directionswitch == false)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (Commandlist.Count == 0)
                {
                    return;
                }
                if (countbool == false)
                {
                    commandindex = Commandlist.Count - 1;
                    Commandlist[commandindex].Execute();
                    countbool = true;
                    return;
                }
                if (commandindex >= 0)
                {
                    Commandlist[commandindex].Execute();

                }
                else
                {
                    commandindex = 0;
                    countbool = false;
                    return;
                }
            }
            directionswitch = true;
            commandindex--;
        }
    }

    public void UIStatus()
    {
        if (agent.isStopped == false)
        {
            if (cyclenum == 0)
            {
                info.text = "Forward";
            }
            if (cyclenum == 1)
            {
                info.text = "Backwards";
            }
            if (cyclenum == 2)
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