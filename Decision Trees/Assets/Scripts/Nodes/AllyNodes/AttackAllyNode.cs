using UnityEngine;
using UnityEngine.AI;

public class AttackAllyNode : Node
{
    private NavMeshAgent agent;
    private AllyAI ai;
    private Transform target;
    private Material attackMaterial;

    private Vector3 currentVelocity;
    private float smoothDamp;

    public AttackAllyNode(NavMeshAgent agent, AllyAI ai, Transform target, Material attackMaterial)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target;
        this.attackMaterial = attackMaterial;
        smoothDamp = 1f;
    }

    public override NodeState Evaluate()
    {
        agent.isStopped = true;
        ai.SetColor(attackMaterial.color);
        Vector3 direction = target.position - ai.transform.position;
        Vector3 currentDirection = Vector3.SmoothDamp(ai.transform.forward, direction, ref currentVelocity, smoothDamp);
        Quaternion rotation = Quaternion.LookRotation(currentDirection, Vector3.up);
        ai.transform.rotation = rotation;
        return NodeState.RUNNING;
    }
}