using UnityEngine;
using UnityEngine.AI;

public class ChaseNPCNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private NpcAI ai;

    public ChaseNPCNode(Transform target, NavMeshAgent agent, NpcAI ai)
    {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (NpcAI.attackMode)
            ai.SetColor(Color.red);
        else
            ai.SetColor(Color.green);
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