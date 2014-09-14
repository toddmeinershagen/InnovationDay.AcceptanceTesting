Feature: DataTable
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: DataTable
	Given a person
	| FirstName | LastName     |
	| Todd      | Meinershagen |
	When I person's first name to "Tammy"
	Then the person should be like the following
	| Field     | Value        |
	| FirstName | Tammy        |
	| LastName  | Meinershagen |