<h1>A REST API created for the Tri Wizard Cup</h1>

Please note: The application focuses less on the operational side of things and focuses more on design principles. Here's an overview of the design decisions and patterns implemented:
-----------------------------------------------------------------------------------

<h3>Repository Pattern</h3> <i>Implemented the repository pattern to separate data retrieval logic from the rest of the application. This promotes modularity and improves maintainability by encapsulating database interactions.</i>


<h3>Unit of Work</h3> <i>Utilized the Unit of Work pattern which is often used in conjuction with the repository pattern. This pattern provides a single interface for the interacing with multiple repositories and also allows for transaction management.</i>


<h3>IDiposable Pattern</h3> <i>Introduced the IDisposable pattern to enable resource cleanup and efficient management of resources. This pattern allows objects to be used in using statements and provides the ability to suppress finalization, optimizing performance.</i>

<h3>CQRS w/ MediatR</h3> <i>Implemented the CQRS pattern with MediatR to segregate read and write operations, thereby improving flexibility, scalability, and code clarity. This separation distinguishes actions that modify data from those that fetch it, simplifying comprehension and facilitating maintenance.</i>
