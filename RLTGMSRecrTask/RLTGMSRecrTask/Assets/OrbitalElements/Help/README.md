# RG.OrbitalElements Namespace

Helper library for orbital elements transformation into Cartesian space positional vector.

## Classes

|                                                    | Class        | Description                                                  |
| -------------------------------------------------- | ------------ | ------------------------------------------------------------ |
| ![Public class](media/pubclass.gif "Public class") | Calculations | Contains mathematical methods used in orbital elements calculations. |


## Structures

|                                                    | Structure     | Description                                  |
| -------------------------------------------------- | ------------- | -------------------------------------------- |
| ![Public class](media/pubclass.gif "Public class") | Vector3Double | 3-dimensional vector with double type values |


# Calculations Class

Contains mathematical methods used in orbital elements calculations.


## Syntax

**C#**

``` C#
public static class Calculations
```

The Calculations type exposes the following members.


## Methods

|                                                              | Name                                                         | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| ![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member") | [CalculateOrbitalPosition](./Calculations.CalculateOrbitalPosition.md) | Given set of orbital elements returns position vector of an orbiting body in Cartesian space which units are 10^3 km. |



## Fields

|                                                              | Name    | Description                       |
| ------------------------------------------------------------ | ------- | --------------------------------- |
| ![Public method](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member") | AU2KM   | Converts astronomical units to km |
| ![Public method](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member") | Deg2Rad | Converts arc degrees to radians   |


# Vector3Double Structure

3-dimensional vector with double type values

## Syntax

**C#**

``` C#
public struct Vector3Double
```

The Vector3Double type exposes the following members.

## Constructors

|                                                       | Name          | Description                                      |
| ----------------------------------------------------- | ------------- | ------------------------------------------------ |
| ![Public method](media/pubmethod.gif "Public method") | Vector3Double | Create 3-dimensional vector with provided values |


## Methods

|                                                       | Name     | Description                                                  |
| ----------------------------------------------------- | -------- | ------------------------------------------------------------ |
| ![Public method](media/pubmethod.gif "Public method") | ToString | Returns the vector in format (x, y, z)<br />(Overrides ValueType.ToString().) |


## Fields

|                                                     | Name | Description |
| --------------------------------------------------- | ---- | ----------- |
| ![Public method](media/pubfield.gif "Public field") | x    |             |
| ![Public method](media/pubfield.gif "Public field") | y    |             |
| ![Public method](media/pubfield.gif "Public field") | z    |             |
