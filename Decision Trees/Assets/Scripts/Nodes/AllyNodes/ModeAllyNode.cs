using UnityEngine;

public class ModeAllyNode : Node
{
    private bool attackMode;

    public ModeAllyNode(bool attackMode)
    {
        this.attackMode = attackMode;
    }

    public override NodeState Evaluate()
    {
        return !attackMode ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}