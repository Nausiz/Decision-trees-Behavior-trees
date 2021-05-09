using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToEndNode : Node
{
    private bool missonEnd;

    public WaitToEndNode(bool missonEnd)
    {
        this.missonEnd = missonEnd;
    }

    public override NodeState Evaluate()
    {
        return !missonEnd ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}