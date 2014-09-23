Feature: Horizontal DataTable
	In order to be able to handle multiple rows
	As a developer
	I want to be able to use horizontal tables

Scenario: Horizontal DataTable
	Given a set of persons
	| FirstName | LastName     | Age | BirthDate  |
	| Todd      | Meinershagen | 41  | 11/23/1972 |
	| Bao       | Vu           | 50  | 5/25/1963  |
	When I update first name for each person to "Kalyan"
	Then the set should look like the following
	| First Name | Last Name    | Age | Birth Date |
	| Kalyan     | Meinershagen | 41  | 11/23/1972 |
	| Kalyan     | Vu           | 50  | 5/25/1963  |