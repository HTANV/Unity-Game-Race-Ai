using UnityEngine;

public partial class AIController : MonoBehaviour
{
    [Header("Ai Basic Settings")]
    public Color StatsColor = Color.white;
    //These are not implemented in the vehicle controller, these only created for TacticalSystem
    public float SteeringSensitivity = 1;
    public float FollowingDistance = 1;
    public float MaximumSpeed = 1;
    public float BrakeForce = 1;

    //Reference to the main vehicle controller
    [HideInInspector] public VehicleController vehicleController;
    private SimpleRacePositionSystem positionSystem;
    private UIManager uiManager;

    //Distance calculating
    private float totalTime = 0f;
    public float totalDistance = 0f;
    public int MyPosition = -1;


    private void Start()
    {

        //Getting the Vehicle controller
        vehicleController = GetComponent<VehicleController>();
        positionSystem = FindObjectOfType<SimpleRacePositionSystem>();
        uiManager = FindObjectOfType<UIManager>();
        
        currentWaypointIndex = 0;
        //initialize detection sensors
        InitializeObstacleSensors();

        InitializeWaypoints();

        if (positionSystem)
            positionSystem.AddParticipant(this);

        InitializeDecisionTree();

        if (uiManager)
        {
            InitializeUI();
        }
    }

    private void FixedUpdate()
    {
        UpdateWaypointsDrive();

    }

    private void Update()
    {
        AvoidObstacles();
        Avoidance();

        CalculateDistance();

        if (positionSystem)
            MyPosition = positionSystem.GetPosition(this);

        UpdateDecisionSystem();

        if (uiManager)
            uiManager.UpdateUI(this);
    }

    private void InitializeUI()
    {
        if (uiManager)
        {
            uiManager.SetUI(this);
        }
    }
    private void InitializeDecisionTree()
    {
        brakingDecision = new BrakingDecision(vehicleController, this);
        overtakingDecision = new OvertakingDecision(vehicleController, this);
        reverseDecision = new ReverseDecision(vehicleController, this);
        steerOppositeDecision = new SteerOppositeDirection(vehicleController, this);

    }
    private void CalculateDistance()
    {
        if (vehicleController.GetCurrentSpeed <= 2) return;

        float deltaTime = Time.deltaTime;
        float currentSpeed = vehicleController.GetCurrentSpeed;

        float distance = currentSpeed * deltaTime;
        totalDistance += distance / 1000;

        totalTime += deltaTime;
    }

    private int counts = 0;
    private string _decisions;
    private string _temp;
    public string GetActiveDecisions()
    {


        counts++;

        if (counts > 500)
        {
            var _overtaking = DecisionComments.GetOvertakingComment(isOvertakingDecision);
            var _braking = DecisionComments.GetBrakingComment(isBrakingDecision);
            var _reversing = DecisionComments.GetReverseComment(isReverseDecision);

            _decisions =
            "Overtake:" + _overtaking + "\n" +
            "Brake:" + _braking + "\n" +
            "Reverse:" + _reversing;

            counts = 0;

            _temp = _decisions;

        }

        return _temp;
    }
}
