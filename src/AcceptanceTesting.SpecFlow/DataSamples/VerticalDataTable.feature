Feature: VerticalDataTable
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Vertical DataTable
	Given a person
	| Field     | Value        |
	| FirstName | Todd         |
	| LastName  | Meinershagen |
	| Age       | 41           |
	When I change the person's first name to "Tammy"
	Then the person should be like the following
	| Field     | Value        |
	| FirstName | Tammy        |
	| LastName  | Meinershagen |
	| Age       | 41           |