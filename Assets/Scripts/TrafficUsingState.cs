using UnityEngine;

public class TrafficUsingState : MonoBehaviour
{
    public StateMachine stateMachine;
    private MeshRenderer[] _meshRenderers;
    private float _time;
    private void Start()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
        stateMachine = new StateMachine(stateMachine.RedLightState, stateMachine.GreenLightState, _meshRenderers);
        stateMachine.Initialize(stateMachine.RedLightState);
    }

    private void Update()
    {
        _time += Time.deltaTime;
        
        if (_time < 15f)
            stateMachine.TransitionTo(stateMachine.GreenLightState);
        
        if (_time >= 15f && _time < 30f)
            stateMachine.TransitionTo(stateMachine.RedLightState);

        if (_time >= 30f)
            _time = 0f;
    }
}
