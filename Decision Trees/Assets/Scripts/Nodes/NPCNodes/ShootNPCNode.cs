using UnityEngine;
using UnityEngine.AI;

public class ShootNPCNode : Node
{
    private NavMeshAgent agent;
    private NpcAI ai;
    private Transform target;

    private Vector3 currentVelocity;
    private float smoothDamp;

    public ShootNPCNode(NavMeshAgent agent, NpcAI ai, Transform target)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target;
        smoothDamp = 1f;
    }

    public override NodeState Evaluate()
    {
        agent.isStopped = true;
        ai.SetColor(Color.red);
        Vector3 direction = target.position - ai.transform.position;
        Vector3 currentDirection = Vector3.SmoothDamp(ai.transform.forward, direction, ref currentVelocity, smoothDamp);
        Quaternion rotation = Quaternion.LookRotation(currentDirection, Vector3.up);
        ai.transform.rotation = rotation;
        return NodeState.RUNNING;
    }
}