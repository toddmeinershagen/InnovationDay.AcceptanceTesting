Feature: DataExamples
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Data Examples
	Given a person with first name of "<OriginalFirstName>" and last name of "<OriginalLastName>"
	When I change person's first name to "<NewFirstName>"
	Then the person should have first name of "<NewFirstName>" and last name of "<OriginalLastName>"

Examples:
| OriginalFirstName | OriginalLastName | NewFirstName |
| Todd              | Meinershagen     | Tammy        |
| Kalyan            | Das              | Reeti        |