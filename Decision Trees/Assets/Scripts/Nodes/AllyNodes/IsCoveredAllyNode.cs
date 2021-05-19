using UnityEngine;

public class IsCoveredAllyNode : Node
{
    private Transform target;
    private Transform origin;

    public IsCoveredAllyNode(Transform target, Transform origin)
    {
        this.target = target;
        this.origin = origin;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(target.transform.position, origin.transform.position);
        if (distance > 50.0f)
        {
            return NodeState.RUNNING;
        }
        return NodeState.FAILURE;
    }
}