using UnityEngine;
using UnityEngine.AI;

public class StopMoveNPCNode : Node
{
    private NavMeshAgent agent;
    private NpcAI ai;
    private Transform target;

    private Vector3 currentVelocity;
    private float smoothDamp;

    public StopMoveNPCNode(NavMeshAgent agent, NpcAI ai, Transform target)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target;
        smoothDamp = 1f;
    }

    public override NodeState Evaluate()
    {
        agent.isStopped = true;
        if (NpcAI.attackMode)
            ai.SetColor(Color.red);
        else
            ai.SetColor(Color.green);
        Vector3 direction = target.position - ai.transform.position;
        Vector3 currentDirection = Vector3.SmoothDamp(ai.transform.forward, direction, ref currentVelocity, smoothDamp);
        Quaternion rotation = Quaternion.LookRotation(currentDirection, Vector3.up);
        ai.transform.rotation = rotation;
        return NodeState.RUNNING;
    }
}