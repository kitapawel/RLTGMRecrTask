# Unity SpaceX API Client

Your task is to prepare Unity project that will fetch data from API and display SpaceX's Tesla Roadster orbiting around the sun in 3D space and 
an interface that will list all SpaceX launches with additional details about the launch provided when interacting with any launch on the 
list.

SpaceX API: https://documenter.getpostman.com/view/2025350/RWaEzAiG

**Required Unity version: 2019.4.8**

## Objectives:

* Project should be targeting either Android or iOS and should be adapted for mobile device usage, with touch input and gestures
* Create main menu that will let the user choose between Tesla Roadster simulation on the orbit of the sun or SpaceX launches browser
* It should be possible to go back to the main menu from either Roadster simulation or launches browser and choose either one again without restarting the game

#### Tesla Roadster simulation
* When the user chooses to see Tesla Roadster on the orbit of the sun he should see some 3D model that symbolizes the sun and a 3D model on it's orbit that symbolizes the car. Use orbital data from CSV file `Roadster orbital elements JPL Horizon.csv` and provided library `OrbitalElements.dll` (or your own implementation) to present sped up simulation of Tesla Roadster position on the orbit of the Sun. This simulation should run with speed of at least 24 hours / second and Roadster's position on the orbit can jump from one position to the next without any interpolation. Docs for `OrbitalElements` are [here](./OrbitalElements/Help/README.md)
* It will suffice if the simulation will only use data between 07.02.2018 and 08.10.2019
* When the simulation ends, it should loop from the beginning of provided data set
* After updating Roadster's position show the last 20 positions as a line that connects to current Roadster's position (think tail of a comet).
* While the sped up simulation is playing and Roadster's position is being updated show all the current orbital data as text in the corner of the screen where current simulation date will be presented in local time zone, not UTC.

#### SpaceX launches browser
* When the user chooses to see SpaceX launches browser in the main menu, he should see fullscreen Unity UI that will present a scrollable list containing interactable elements. Each interactable element in the list should represent one SpaceX launch and provide text with name of the mission and number of payloads that were involved in the mission, as well as the name of the rocket used in the launch and it's country of origin.
* Each launch in the list should have an image that symbolizes if the launch has already happened or it is a future launch.
* Tapping on any launch element in the list should open a popup window with information about each ship used in the launch: number of missions it was used in, name, ship type and home port

## Optional objectives:

(listed in random order)
* Create your own solution for calculating Roadster's position from orbital data
* Use orbital data after 08.10.2019 from the provided CSV file while interpolating Roadster's position if there is more than 24 hours between consecutive data records - Roadster position in simulation should not suddenly jump between positions, but move smoothly while maintaining close to constant speed of simulation
* Implement touch gestures to rotate the camera when looking at Roadster's orbit simulation
* SpaceX Launches browser should use object pooling to optimize resources consumption
* In launch details popup create a button for each ship that will open url to the photo of the ship

## Orbital Elements

We are providing a library (OrbitalElements.dll) that will help you with transforming orbital elements into cartesian space positional vector.
