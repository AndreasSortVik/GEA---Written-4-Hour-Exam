using System;
using UnityEngine;

// Base code for creating statemachine is taken from
// Level_Up_Your_Code_With_Game_Programming_Pattern

public interface IState
{
    public void Enter(MeshRenderer[] meshRenderers)
    {
        
    }

    public void Update()
    {
        
    }

    public void Exit(MeshRenderer[] meshRenderers)
    {
        
    }
}

public abstract class GreenLight : IState
{
    public Color CurrentColor;
    public void Enter(MeshRenderer[] meshRenderers)
    {
        CurrentColor = Color.green;
        meshRenderers[1].material.color = CurrentColor;
    }

    public void Exit(MeshRenderer[] meshRenderers)
    {
        CurrentColor = Color.black;
        meshRenderers[1].material.color = CurrentColor;
    }
}

public abstract class RedLight : IState
{
    public Color CurrentColor;
    
    public void Enter(MeshRenderer[] meshRenderers)
    {
        CurrentColor = Color.red;
        meshRenderers[0].material.color = CurrentColor;
    }

    public void Exit(MeshRenderer[] meshRenderers)
    {
        CurrentColor = Color.black;
        meshRenderers[0].material.color = CurrentColor;
    }
}

[Serializable] public class StateMachine
{
    public IState CurrentState { get; private set; }

    public RedLight RedLightState;
    public GreenLight GreenLightState;
    public MeshRenderer[] MeshRenderers;

    public StateMachine(RedLight redLightState, GreenLight greenLightState, MeshRenderer[] meshRenderers)
    {
        RedLightState = redLightState;
        GreenLightState = greenLightState;
        MeshRenderers = meshRenderers;
    }
    
    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter(MeshRenderers);
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit(MeshRenderers);
        CurrentState = nextState;
        nextState.Enter(MeshRenderers);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}
