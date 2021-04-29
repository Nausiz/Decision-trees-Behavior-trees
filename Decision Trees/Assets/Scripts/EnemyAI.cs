using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth=100;
    [SerializeField] private float lowHealthThreshold=50;
    [SerializeField] private float healthRestoreRate=1;

    [SerializeField] private float chasingRange=15;
    [SerializeField] private float shootingRange=5;


    [SerializeField] private Transform playerTransform;
    [SerializeField] private Cover[] availableCovers;

    [SerializeField] private Slider HPThresholdSlider;
    [SerializeField] private Slider HPRegenSlider;
    [SerializeField] private Slider ChaseRangeSlider;
    [SerializeField] private Slider AtackRangeSlider;



    private Material material;
    private Transform bestCoverSpot;
    private NavMeshAgent agent;

    private Node topNode;

    private float _currentHealth;
    public float currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, startingHealth); }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    private void Start()
    {
        _currentHealth = startingHealth;

        if (HPThresholdSlider != null && HPRegenSlider != null && ChaseRangeSlider !=null && AtackRangeSlider != null)
        {
            HPThresholdSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            HPRegenSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); }); 
            ChaseRangeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            AtackRangeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }
        ConstructBehahaviourTree();
    }

    private void ConstructBehahaviourTree()
    {
        IsCoveredAvailableNode coverAvailableNode = new IsCoveredAvailableNode(availableCovers, playerTransform, this);
        GoToCoverNode goToCoverNode = new GoToCoverNode(agent, this);
        HealthNode healthNode = new HealthNode(this, lowHealthThreshold);
        IsCoveredNode isCoveredNode = new IsCoveredNode(playerTransform, transform);
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
        RangeNode chasingRangeNode = new RangeNode(chasingRange, playerTransform, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, playerTransform, transform);
        ShootNode shootNode = new ShootNode(agent, this, playerTransform);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode });

        Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvailableNode, goToCoverNode });
        Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence });
        Selector tryToTakeCoverSelector = new Selector(new List<Node> { isCoveredNode, findCoverSelector });
        Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

        topNode = new Selector(new List<Node> { mainCoverSequence, shootSequence, chaseSequence });
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.white);
            agent.isStopped = true;
        }
        currentHealth += Time.deltaTime * healthRestoreRate;
    }

    public void ValueChangeCheck()
    {
        lowHealthThreshold = HPThresholdSlider.value;
        healthRestoreRate = HPRegenSlider.value;
        chasingRange = ChaseRangeSlider.value;
        shootingRange = AtackRangeSlider.value;

        ConstructBehahaviourTree();
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
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