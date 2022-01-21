# UnityInputSystem
VCS Input System implementation in Unity.<br>
This project contains Modern Controller and Classic Joystick Mapping using both <b>Unity Input Manager</b> and <b>Unity Input System</b>.
<br>
The Folder contains : <ol><li>Documentation</li><li> Input Manager</li><li> Input System</li> </ol>

<ul>
<li><b>Documentation</b></li>
  The documentation contains the controller layout which are mapped in Modern Controller and Classic Joystick for Atari VCS.
  <li><b> Input Manager</b></li>
  Unity Input Manager is an old implementation of Unity which reads the input from any HID device natively. While using Unity Input Manager, there can be issues with hot plugging ie. if you connect a controller after running the game, the controller sometimes may not work in Linux based devices. Unity has moved on to a newer Implementation ie <i>Unity Input System</i>.
  <li><b> Input System</b></li>
Unity Input System is the newest implementation of Unity to poll Input from devices.The Input System is based on Controller Player Input Actions. Getting input directly from an Input Device is quick and convenient, but requires a separate path for each type of Device. That also makes it harder to later change which Device Control triggers a specific event in the game. Alternatively, you can use Actions as an intermediary between Devices and the in-game responses they trigger. The easiest way to do this is to use the PlayerInput component. You can read more about Unity Input System <a href="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html#getting-input-indirectly-through-an-input-action">here</a>.<ul><li> Local Multiplayer</li></ul>
Using Unity's new Input System, it is easier to implement a local multiplayer game binded to controller. There's an example of local Multiplayer game in the Input System folder
