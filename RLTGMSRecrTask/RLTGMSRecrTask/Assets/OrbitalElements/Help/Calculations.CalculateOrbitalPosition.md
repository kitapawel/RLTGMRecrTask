# Calculations.CalculateOrbitalPosition Method 

Given set of orbital elements returns position vector of an orbiting body in Cartesian space which units are 10^3 km.

## Syntax

**C#**

``` C#
public static Vector3Double CalculateOrbitalPosition(
	double semimajorAxis,
	double eccentricity,
	double inclination,
	double longitudeOfAscendingNode,
	double periapsisArgument,
	double trueAnomaly
)
```

#### Parameters

***semimajorAxis***

	Type: System.Double
	As AU

***eccentricity***

	Type: System.Double
	Between 0 and 1

***inclination***

	Type: System.Double
	As degrees

***longitudeOfAscendingNode***

	Type: System.Double
	As degrees

***periapsisArgument***

	Type: System.Double
	As degrees

***trueAnomaly***

	Type: System.Double
	As degrees

#### Return Value

Type: Vector3Double
Positional vector in 10^3 km.
