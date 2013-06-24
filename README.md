Dynamical Systems Net
=====================

A set of base classes and solver for simulating a distributed, graphical, dynamical system 
of differential equations. Includes a sparse, variable-indexed vector class, and one 4th Runga-Kutta solver. 
An abstract interface for solvers exists to enable other numerical implementations. Variable dependencies
are expressed as weighted connections in the graph, making this suitable for dynamical machine learning models
as well as simpler ODE models.

Base Classes
------------
The base class design is composed principally of 
<code>DynamicalNode</code>, 
<code>DynamicalSystem</code>, 
<code>IIntegrator</code>, 
<code>NodeLink</code>, 
and <code>VectorOI</code>. 

To define your derivative <code>dy_1/dt</code> you simply subclass and implement
virtual method <code>DynamicalNode.F(y,t)</code>, and instantiate it with name e.g. "y1". Dependencies on other variables are explicitly defininable and accessible
via access to the list of incoming node edges.

Example Project
---------------
The examples project includes:
+ A sine-wave generator system.
+ A linear-coupled two variable oscillating system.
+ Two (2) gradient-frequency neural network (GFNN) systems.
+ A Hebbian-learning example, forming connection weights ontop of a GFNN system.
