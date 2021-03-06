using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AllyAI : MonoBehaviour
{
    [SerializeField] private float chasingRange = 20;
    [SerializeField] private float attackRange = 5;
    [SerializeField] private bool attackMode = true;

    [SerializeField] private Transform enemyTransform;
    [SerializeField] private Cover[] availableCovers;

    [SerializeField] private Toggle modeToggle;

    [SerializeField] private Material chaseAllyMaterial;
    [SerializeField] private Material escapeAllyMaterial;
    [SerializeField] private Material attackAllyMaterial;

    private Material material;
    private Transform bestCoverSpot;
    private NavMeshAgent agent;

    private Node topNode;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    private void Start()
    {
        modeToggle.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        CreateDecisionTree();
    }
    
    private void CreateDecisionTree()
    {
        IsCoveredAvailableAllyNode coverAvailableNode = new IsCoveredAvailableAllyNode(availableCovers, enemyTransform, this);
        GoToCoverAllyNode goToCoverNode = new GoToCoverAllyNode(agent, this, escapeAllyMaterial);
        ModeAllyNode modeAllyNode = new ModeAllyNode(attackMode);
        IsCoveredAllyNode isCoveredNode = new IsCoveredAllyNode(enemyTransform, transform);
        ChaseAllyNode chaseNode = new ChaseAllyNode(enemyTransform, agent, this, chaseAllyMaterial);
        RangeNode chasingRangeNode = new RangeNode(chasingRange, enemyTransform, transform);
        RangeNode shootingRangeNode = new RangeNode(attackRange, enemyTransform, transform);
        AttackAllyNode attackNode = new AttackAllyNode(agent, this, enemyTransform, attackAllyMaterial);
        
        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });

        Sequence attackSequence = new Sequence(new List<Node> { shootingRangeNode, attackNode });

        Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvailableNode, goToCoverNode });

        Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence });

        Selector tryToTakeCoverSelector = new Selector(new List<Node> { isCoveredNode, findCoverSelector });

        Sequence mainCoverSequence = new Sequence(new List<Node> { modeAllyNode, tryToTakeCoverSelector });

        topNode = new Selector(new List<Node> { mainCoverSequence, attackSequence, chaseSequence });
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.white);
            agent.isStopped = true;
        }
    }

    public void ValueChangeCheck()
    {
        attackMode = modeToggle.isOn;
        CreateDecisionTree();
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void SetBestCoverSpot(Transform bestCoverSpot)
    {
        this.bestCoverSpot = bestCoverSpot;
    }

    public Transform GetBestCoverSpot()
    {
        return bestCoverSpot;
    }
}