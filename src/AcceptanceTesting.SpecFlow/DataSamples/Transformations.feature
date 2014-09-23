Feature: Transformations
	In order to match more complex data types
	As a developer
	I want to leverage step transforms

Scenario: Add two numbers

	When I set birthdate to 3 days from now
	Then the birthdate should be in 3 days
