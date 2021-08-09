# TrainTheDog
Unity ML Agents project to train a virtual dog to use a tray.

The idea is simple. We have a room with a dog and a tray. The Dog should find the tray and do its job on it and nowhere else.
If the Dog does it outside of the tray it gets penalazed. If the Dog hits the wall, it gets penalized as well. It is done to avoid cases when it just moves towards the wall and stuck there forever. And finally, if it does the job on the tray, then it gets rewarded. In any of the above cases, the episode ends and the room restarts.

To achieve this goal, the Dog should get some information about enviroment arount it. It has Ray Perseption Sensor 3D component with 3 rays per direction and 70 degrees viewing angle. It allows it to see where are walls and find the tray. The only observation added manually is a boolean value of whether it is allowed or not allowed to do the job there. The collider of the tray is raised a little in order to be visible for the sensors.

The dog has 3 continuous actions. For turning, moving and "unloading" respectively.

Versions of packages used:<br />
  ML Agents (Unity)   : 2.1.0-exp.1<br />
  PyTorch             : 1.9.0<br />
  ML Agents (Python)  : 0.27.0<br />
  
In order to run the project, you should clone the repository, and install corresponding packages (newer versions probably will work as well). After thats done, you can start training the model by typing <<mlagents-learn --run-id=ANY_ID_HERE>>.

You can also use config file in Cofigs folder if you want to tweak learning parameters. You can change max_steps atribute in the configuration file in order to increase training period. To start training process with config file, type <<mlagents-learn Configs\DogBehaviorConfig.yaml --run-id=ANY_ID_HERE>>.
