using System;
using UnityEngine;
using UnityEngine.Serialization;

public class TrafficUsingSwitch : MonoBehaviour
{
    [SerializeField] private AICubeMovement aiCubeMovementScript;
    
    private MeshRenderer[] _meshRenderers;
    private float _time;
    private Color _color;

    // Initializes array and sets all traffic light components to the color black
    private void Start()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material.color = Color.black;
        }
    }

    // Changes the traffic lights depending on time in a loop
    private void Update()
    {
        _time += Time.deltaTime;
        
        // Changes to red traffic light
        if (_time < 5)
            ChangeTrafficLight("red");
        
        // Changes to green light
        if (_time >= 10f && _time < 15)
            ChangeTrafficLight("green");

        // Resets timer
        if (_time >= 15)
            _time = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "AI Cube")
        {
            //print("AI Cube has triggered box collider");
            
            // Stops AI Cube
            if (_color == Color.red)
                aiCubeMovementScript.PauseAnimation();
            
            // Resumes AI Cube
            if (_color == Color.green)
                aiCubeMovementScript.PlayAnimation();
        }
    }

    // Uses switch case to change the traffic light
    private void ChangeTrafficLight(string colorName)
    {
        switch (colorName)
        {
            case "red":
                _color = Color.red;
                ChangeTrafficLightsToBlack();
                _meshRenderers[0].material.color = _color;
                break;
            case "green":
                _color = Color.green;
                ChangeTrafficLightsToBlack();
                _meshRenderers[1].material.color = _color;
                break;
        }
    }
    
    // Changes all traffic light colors to black
    private void ChangeTrafficLightsToBlack()
    {
        foreach (var meshRenderer in _meshRenderers)
            meshRenderer.material.color = Color.black;
    }
}
