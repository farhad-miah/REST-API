<h1>A REST API created for the Tri Wizard Cup</h1>

Please note: The application focuses less on the operational side of things and focuses more on design principles and features. Here's an overview of the design patterns and features implemented:
-----------------------------------------------------------------------------------

<h3>Repository Pattern</h3> <i>Implemented the repository pattern to separate data retrieval logic from the rest of the application. This promotes modularity and improves maintainability by encapsulating database interactions.</i>


<h3>Unit of Work</h3> <i>Utilised the Unit of Work pattern which is often used in conjuction with the repository pattern. This pattern provides a single interface for the interacing with multiple repositories and also allows for transaction management.</i>


<h3>IDiposable Pattern</h3> <i>Introduced the IDisposable pattern to enable resource cleanup and efficient management of resources. This pattern allows objects to be used in using statements and provides the ability to suppress finalization, optimizing performance.</i>


<h3>CQRS w/ MediatR</h3> <i>Implemented the CQRS pattern with MediatR to segregate read and write operations, thereby improving flexibility, scalability, and code clarity. This separation distinguishes actions that modify data from those that fetch it, simplifying comprehension and facilitating maintenance.</i>


<h3>Identity</h3> <i>Integrated Identity to enforce authorization for certain endpoints, such as the DeleteWizard endpoint in the Wizard API controller. This enhances security by requiring authentication for sensitive operations.</i>


<h3>API Versioning</h3> <i>Added in versioning to the API as well swagger ui functionality to test these API changes. Versioning allows the safe introduction of new changes while also supporting legacy client.</i>
