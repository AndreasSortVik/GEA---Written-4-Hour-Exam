How to run game:
Open the scene named ExamScene and click on Play


Scripts:
In my Scripts folder I have created 5 different scripts; AICubeMovement, LapManager, StateMachine, TrafficUsingState, TrafficUsingSwitch.

AICubeMovement:
Includes all logic for the AI Cube when moving around the spline circle. The PauseAnimation and PlayAnimation method is called by the TrafficUsingSwitch state, whilst staying inside the traffic object's trigger box. UpdateLapInfo is called by LapManager script when it's trigger box is entered by the cube.

LapManager:
Includes all logic for counting the amount of laps done by the cube.

StatMachine:
I tried creating using State Pattern to check what state the traffic light is in, but couldn't get it to work. The StateMachine scripts includes the interface IState and the two different state classes RedLight and GreenLight, as well as including the class for the StateMachine.

TrafficUsingState:
Includes all logic for changing the traffic light state after a certain amount of time. I tried using it to call the StateMachine and change the traffic light state, but couldn't get it to work.

TrafficUsingSwitch:
Had to go over to use switch cases for changing the traffic light's state. This script includes all logic for changing the traffic light state.
I first change the traffic light colors to black in start, and then change one to red. The logic for changing the traffic light state is inside the Update Event Function.
This script is in the parent object of the individual traffic light cubes. I get the child's mesh renderer in the Start Event Function.


Additional Information:
Each lap time is displayed in Unity's log using the print funciton.
I did not get enough time to create a playable cube object, but Meisam mentioned that one cube was enough.
I could not figure out how to get the AI Cube's speed to display after every lap, because I cannot use RigidBody on that object, therefore not being able to get the Speed of the object. I could've calculated the speed by myself using Time.fixedDeltaTime, but did not have enough time.

