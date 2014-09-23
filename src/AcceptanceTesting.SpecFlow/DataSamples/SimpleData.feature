Feature: SimpleDataFeature
	In order to pass simple data values to my tests
	As a developer
	I want to be able to use string literals and numbers

Scenario: SimpleData
	Given a person with a first name of "Todd"
	And a person with a last name of "Meinershagen"
	And a person with age of 41
	When I change the first name to "Tammy"
	Then the first name should be "Tammy"
	And the last name should be "Meinershagen"
	And the age should be 41
