Feature: AllHooks
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@run
Scenario: Executing Hooks 1
	Given I have hooks
	When I execute
	Then hooks execute

Scenario: Executing Hook 2 	
	Given I have hooks
	When I execute
	Then hooks execute