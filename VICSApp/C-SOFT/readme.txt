THIS DOCUMENT TO SHOW HOW THE STRUCTURE THE SOLUTION WAS BUILT

1. Application and GUI
DESC: this contains all projects which might be the application console, end-user UI application

- CS.Application: the WPF application
- VSDGateway: VSD gateway console application
- .... (all gateways if any)

2. Service & API
DESC: the api webservice or the service that is used to comunicate between applications in the whole one system

- CS.CoreApi: the core api web service

3. Application business
DESC: all business implementations are put in here


4. Domain objects
DESC: the entity framework POCO

5. Commmon libraries
DESC: all the shared libraries that might be used throughout the projects

7. Unittests
DESC: all unittest projects

----------------------------------------------
Document & All Production settings files

