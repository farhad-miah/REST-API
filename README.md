A REST API I created for the Tri Wizard Cup
-----------------------------------------------------------------------------------

It uses the repository pattern to separate the logic which retrieves the sata from the database from the rest of the application.
I have also decided to add in the Unit of Work pattern which is often used in conjuction with the repository pattern as it provides a single interface for the interacing with multiple repositories and also allows for transaction management

FYI - I added in the IDisposable pattern to the Unit of Work just to show how it can be implemented. The reason for why it's not needed is because the lifetime of the objects are managed within the scope of the HTTP request.
