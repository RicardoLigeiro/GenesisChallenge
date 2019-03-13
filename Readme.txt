Breef explantion on the software structure

The idea was to set it up in the current best practices on sofware development.

The solution have 5 projects

GenesisChallenge (UI)
	DevExpress controls used. Grid, TextBox, ProgressPanel
	(No need to set more) [Also ignore the design please :-)]
	DI of repository services (GenesisChallenge.Repository)

GenesisChallenge.Entities
	Where our model lives

GenesisChallenge.EntityFramework
	ORM Mapper that holds just that
	The idea is to block access to the edmx to the UI or any other service

GenesisChallenge.Repository
	Our services class
	It supplies the interface and the impelementation that gets DI on the UI
	Exposes the methods of get orders and edit customers

GenesisChallenge.Tests
	Tests just for the Repository (Services tests, Moks and integration tests)
	We would need a tool like TestComplete to do those
