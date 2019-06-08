# Unity SpaceX API Client

Your task is to prepare Unity project that will fetch and display SpaceX's Tesla Roadster orbiting around the sun in 3D space and 
an interface that will list all SpaceX launches with additional details about the launch provided when interacting with any launch on the 
list.

### Objectives:

* Project should be targeting either Android or iOS and should be adapted for mobile device usage, with touch input and gestures
* You can use a library that we can provide by your request to assist you with calculating Roadster's position from orbital data that you will get from the API
* Create main menu that will let the user to choose between seeing Tesla Roadster on the orbit or exploring SpaceX launches list
* When the user chooses to see Tesla Roadster on the orbit he should see some 3D model that symbolizes the sun and a 3D model on it's orbit that symbolizes the car. Every 10 minutes SpaceX API should be fetched for new orbital data of the Roadster (data that the API returns changes every 10 minutes). Roadster's position on the orbit should be updated and a visible line should be created between last and current position on an orbit.
* When the user chooses to see SpaceX launches list in the main menu, he should see fullscreen Unity UI that will present a scrollable list containing interactable elements. Each interactable element in the list should represent one SpaceX launch and provide text with name of the mission and number of payloads that were involved in the mission, as well as the name of the rocket used in the launch and it's country of origin.
* Each launch in the list should have an image that symbolizes if the launch has already happened or it is a future launch.
* Tapping on any launch element in the list should open a popup window with information about each ship used in the launch: number of missions it was used in, name, ship type and home port

### Optional objectives:

* Create your own solution for calculating Roadster's position from orbital data fetched from the API.
* Implement touch gestures to rotate the camera when looking at Roadster's orbit
* In launch details popup create a button for each ship that will open url to the photo of the ship
