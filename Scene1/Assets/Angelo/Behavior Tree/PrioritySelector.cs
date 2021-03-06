﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySelector : Node
{
    /*
         The priority selector class will go through the nodes according to the priority value that was assigned to them
         If a node returns successfull, it will stop going through the nodes
    */

    public PrioritySelector(int desiredPriority, string desiredName) : base(desiredPriority, desiredName)
    {
        this.NodePriority = desiredPriority;
        this.NodeName = desiredName;
    }

    public override void NodeBehavior(Handler agent, bool isInTrigger, Collider doorCollider, float doorOpenTimer, GameObject player, float distanceToPlayer, float angle, float enemyFieldOfView, float rotationSpeed, Vector3 directionBetweenEnemyAndPlayer)
    {
        for(int i = 0; i < this.Children.Count; i++)
        {
            this.Children[i].NodeBehavior(agent, isInTrigger, doorCollider, doorOpenTimer, player, distanceToPlayer, angle, enemyFieldOfView, rotationSpeed, directionBetweenEnemyAndPlayer);

            if (this.Children[i].BoolCheckNodeState(NodeStates.success))
            {
                BoolCheckNodeState(NodeStates.success);
                return;
            }
            else if (this.Children[i].BoolCheckNodeState(NodeStates.running))
            {
                BoolCheckNodeState(NodeStates.running);
                return;
            }
            else if (this.Children[i].BoolCheckNodeState(NodeStates.failed))
            {

            }
        }
        base.BoolCheckNodeState(NodeStates.failed);
    }
}
