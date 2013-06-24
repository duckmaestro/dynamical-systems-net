Dynamical Systems Net
=====================

A set of base classes and solver for simulating a distributed, graphical, dynamical system 
of differential equations. Includes a sparse, variable-indexed vector class, and one 4th Runga-Kutta solver. 
An abstract interface for solvers exists to enable other numerical implementations. Variable dependencies
are expressed as weighted connections in the graph, making this suitable for dynamical machine learning models
as well as simpler ODE models. Written in C# and targetting .NET Framework 4.0 (using System.Numerics).

Base Classes
------------
The base class design is composed principally of 
<code>DynamicalNode</code>, 
<code>DynamicalSystem</code>, 
<code>IIntegrator</code>, 
<code>NodeLink</code>, 
and <code>VectorOI</code>. 

To define your derivative <code>dy_i/dt</code> you simply subclass and implement
virtual method <code>DynamicalNode.F(y,t)</code>, and instantiate it with name e.g. "y_i". 
Dependencies on other variables are explicitly defininable and accessible
via access to the list of incoming node edges.

Example Project
---------------
The examples project includes:
+ A sine-wave generator system.
+ A linear-coupled two variable oscillating system.
+ Two (2) gradient-frequency neural network (GFNN) systems.
+ A Hebbian-learning example, forming connection weights ontop of a GFNN system.

Original Motivation
-------------------
This project comes from efforts toward recreating a cognitive model of musical perception 
and tonality learning, for course CSE 258A at U.C. San Diego. The final report on this effort
is available below.

[Exploring a Neurological Model for Cross-Cultural Consonance and Dissonance in Music Perception: CSE 258A Project Final Report]
(http://www.scribd.com/doc/148918615/Exploring-a-Neurological-Model-for-Cross-Cultural-Consonance-and-Dissonance-in-Music-Perception-CSE-258A-Project-Final-Report)
