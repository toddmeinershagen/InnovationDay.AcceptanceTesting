Feature: SimpleDataFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: SimpleData
	Given a person with a first name of "Todd"
	And a person with a last name of "Meinershagen"
	When I change the first name to "Tammy"
	Then the first name should be "Tammy"
	And the last name should be "Meinershagen"
