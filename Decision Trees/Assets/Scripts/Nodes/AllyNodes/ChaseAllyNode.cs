using UnityEngine;
using UnityEngine.AI;

public class ChaseAllyNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private AllyAI ai;
    private Material chaseAllyMaterial;

    public ChaseAllyNode(Transform target, NavMeshAgent agent, AllyAI ai, Material chaseAllyMaterial)
    {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
        this.chaseAllyMaterial = chaseAllyMaterial;
    }

    public override NodeState Evaluate()
    {
        ai.SetColor(chaseAllyMaterial.color);
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if (distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}