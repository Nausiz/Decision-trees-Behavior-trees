using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToCoverAllyNode : Node
{
    private NavMeshAgent agent;
    private AllyAI ai;
    private Material escapeAllyMaterial;

    public GoToCoverAllyNode(NavMeshAgent agent, AllyAI ai, Material escapeAllyMaterial)
    {
        this.agent = agent;
        this.ai = ai;
        this.escapeAllyMaterial = escapeAllyMaterial;
    }

    public override NodeState Evaluate()
    {
        Transform coverSpot = ai.GetBestCoverSpot();
        if (coverSpot == null)
            return NodeState.FAILURE;
        ai.SetColor(escapeAllyMaterial.color);
        float distance = Vector3.Distance(coverSpot.position, agent.transform.position);
        if (distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(coverSpot.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }


}