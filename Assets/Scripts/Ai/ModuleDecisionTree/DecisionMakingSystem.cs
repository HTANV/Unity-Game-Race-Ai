using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DecisionComments
{
    internal class Sentences
    {
        public static string[] Braking = new string[]
        {
        "I'm applying the brakes to keep a safe distance",
        "Time to slow down a bit",
        "Making sure we stay in control on sharp turns",
        "Braking to avoid a collision ahead",
        "Slowing down for the upcoming curve"
        };

        public static string[] Overtaking = new string[]
        {
        "Trying to pass the slower car",
        "Changing the lanes to overtake you",
        "Time to get rid of this slower vehicle",
        "I was switching the lanes for an opportunity",
        "Overtaking to maintain my speed"
        };

        public static string[] Reverse = new string[]
        {
        "I'm putting the car in reverse to back out",
        "Let's back up a bit to get a better angle",
        "Reversing to maneuver out of this tight spot",
        "Backing up to avoid an obstacle ahead",
        };
    }

    public static string GetBrakingComment(bool isBrakingDecision)
    {
        if (isBrakingDecision)
        {
            int randomIndex = Random.Range(0, Sentences.Braking.Length);
            return Sentences.Braking[randomIndex];
        }
        return string.Empty;
    }

    public static string GetOvertakingComment(bool isOvertakingDecision)
    {
        if (isOvertakingDecision)
        {
            int randomIndex = Random.Range(0, Sentences.Overtaking.Length);
            return Sentences.Overtaking[randomIndex];
        }
        return string.Empty;
    }

    public static string GetReverseComment(bool isReverseDecision)
    {
        if (isReverseDecision)
        {
            int randomIndex = Random.Range(0, Sentences.Reverse.Length);
            return Sentences.Reverse[randomIndex];
        }
        return string.Empty;
    }
}

public abstract class DecisionNode
{
    public VehicleController controller;
    public AIController aiController;

    public DecisionNode(VehicleController controller, AIController aiController)
    {
        this.controller = controller;
        this.aiController = aiController;
    }

    public abstract bool MakeDecision();
}

public class BrakingDecision : DecisionNode
{
    public BrakingDecision(VehicleController controller, AIController aiController) : base(controller, aiController) { }

    private bool CheckFrontCollision(float maxDistance)
    {
        return base.aiController.Collision_OnFront && base.aiController.CollisionDistance < maxDistance;
    }
    private bool SpeedIsEnoughToSlow
    {
        get
        {
            return base.controller.GetCurrentSpeed > 10;
        }
    }
    private bool ValidDistanceToPathPoint
    {
        get
        {
            return aiController.DistanceToPathPoint < 15 && aiController.DistanceToPathPoint > 5;
        }
    }
    public override bool MakeDecision()
    {
        if (ValidDistanceToPathPoint)
        {
            if (controller.GetCurrentSpeed > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return CheckFrontCollision(10f) && SpeedIsEnoughToSlow;
        }
    }
}

public class ReverseDecision : DecisionNode
{
    public ReverseDecision(VehicleController controller, AIController aiController) : base(controller, aiController) { }

    private bool ThereIsSomethingOnBack
    {
        get
        {
            return base.aiController.ThereIsSomethingOnBack;
        }
    }
    private bool ThereIsSomethingOnFront
    {
        get
        {
            return base.aiController.Collision_OnFront;
        }
    }
    private bool SpeedIsLowToReverse
    {
        get
        {
            return base.controller.GetCurrentSpeed < 7;
        }
    }
    private bool Braking => base.aiController.IsBrakingDecision;

    public override bool MakeDecision()
    {

        return !ThereIsSomethingOnBack && SpeedIsLowToReverse && ThereIsSomethingOnFront;
    }
}
public class SteerOppositeDirection : DecisionNode
{
    public SteerOppositeDirection(VehicleController controller, AIController aiController) : base(controller, aiController) { }
    public override bool MakeDecision()
    {
        return controller.isMovingReverse;
    }
}

public class OvertakingDecision : DecisionNode
{
    public OvertakingDecision(VehicleController controller, AIController aiController) : base(controller, aiController) { }
    protected int MyPosition
    {
        get
        {
            return base.aiController.MyPosition;
        }
    }
    public override bool MakeDecision()
    {
        return MyPosition > 1;
    }
}

public partial class AIController
{


    private BrakingDecision brakingDecision;
    private OvertakingDecision overtakingDecision;
    private ReverseDecision reverseDecision;
    private SteerOppositeDirection steerOppositeDecision;

    private bool isBrakingDecision;
    private bool isOvertakingDecision;
    private bool isReverseDecision;
    private bool isSteerOppositeDecision;

    public bool IsBrakingDecision => isBrakingDecision;
    public bool IsSpeedupDecision => isOvertakingDecision;
    public bool IsReverseDecision => isReverseDecision;
    public bool IsSteerOpposite => isSteerOppositeDecision;

    private void UpdateDecisionSystem()
    {
        isBrakingDecision = brakingDecision.MakeDecision();
        isOvertakingDecision = overtakingDecision.MakeDecision();
        isReverseDecision = reverseDecision.MakeDecision();
        isSteerOppositeDecision = steerOppositeDecision.MakeDecision();

    }
}
