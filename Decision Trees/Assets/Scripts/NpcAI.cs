using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAI : MonoBehaviour
{
    [SerializeField] private float chasingRange = 20;
    [SerializeField] private float stopMoveRange = 5;
    [SerializeField] public static bool attackMode = false;
    [SerializeField] private Transform playerTransform;

    private Material material;
    private NavMeshAgent agent;
    public static bool missionEnd=false;

    private Node topNode;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    private void Start()
    {
        CreateDecisionTree();
    }

    private void CreateDecisionTree()
    {
        ChaseNPCNode chaseNode = new ChaseNPCNode(playerTransform, agent, this);
        RangeNode chasingRangeNode = new RangeNode(chasingRange, playerTransform, transform);
        RangeNode stopMoveRangeNode = new RangeNode(stopMoveRange, playerTransform, transform);
        StopMoveNPCNode stopMoveNode = new StopMoveNPCNode(agent, this, playerTransform);
        WaitToEndNode waitToEndNode = new WaitToEndNode(missionEnd);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });

        Sequence stopMoveSequence = new Sequence(new List<Node> { stopMoveRangeNode, stopMoveNode });

        topNode = new Selector(new List<Node> {waitToEndNode, stopMoveSequence, chaseSequence });
    }

    private void Update()
    {
        Vector3 relativePos = playerTransform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;

        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.white);
            agent.isStopped = true;
        }

        if (missionEnd)
        {
            CreateDecisionTree();
        }
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }
}