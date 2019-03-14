Breef explantion on the software structure

The idea was to set it up in the current best practices on sofware development. (OOP, DI, Abstraction, etc)
and have a seperate layer for each context.
So instead of using and doing drag and drop on the UI, I wanted to try this way. AS in many big software
scenarios we have to "dig in the code..." :-)

The solution have 5 projects

GenesisChallenge (UI)
	DevExpress controls used. Grid, TextBox, ProgressPanel
	(No need to set more) [Also ignore the design please :-)]
	DI of repository services (GenesisChallenge.Repository)

GenesisChallenge.Entities
	Where our model lives
	Due to the simplicity of the model only on class was created, as it serves our needs

GenesisChallenge.EntityFramework
	ORM Mapper that holds just that
	The idea is to block access to the edmx to the UI or any other service, and be worked by
	the repository layer 
	(this is open to discussion as in the new .net core with code first we expose directly)

GenesisChallenge.Repository
	Our services class
	It supplies the interface and the implementation that gets DI on the UI
	Exposes the methods of get orders and edit customers

GenesisChallenge.Tests
	Tests just for the Repository (Services tests, Moks and integration tests)
	We would need a tool like TestComplete to do the UI

NOTE: We could might have a service layer that would work with the repository and be exposed to the UI, but
those are a matter of choose.

Thanks, hope you like it
Ricardo