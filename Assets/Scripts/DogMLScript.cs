using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class DogMLScript : Agent
{
    [SerializeField] private EnviromentControllerScript envController;
    [SerializeField] private DogControllerScript dogController;

    public override void Initialize()
    {
        //======Checking if the agent is in training mode======//
        envController.SetTrainingMode(Academy.Instance.IsCommunicatorOn);
    }
    public override void OnEpisodeBegin()
    {
        envController.ResetWorld();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;

        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
        continuousActions[2] = Input.GetAxisRaw("Jump");
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(dogController.IsAllowed());
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float angle = actions.ContinuousActions[0];
        float movement = actions.ContinuousActions[1];
        float doTheJob = actions.ContinuousActions[2];

        if (movement < 0.0f) movement = 0.0f;

        if (doTheJob > 0.5)
        {
            dogController.DoTheJob();
            if (dogController.IsAllowed())
            {
                SetReward(1.0f);
                envController.Success();
                EndEpisode();
            }
            else
            {
                SetReward(-1.0f);
                envController.Fail();
                EndEpisode();
            }
        }

        dogController.Rotate(angle);
        dogController.Move(movement);
    }


    private void OnCollisionEnter(Collision collision)
    {
        SetReward(-1.0f);
        EndEpisode();
    }
}
