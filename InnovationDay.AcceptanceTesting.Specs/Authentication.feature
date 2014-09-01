Feature: Authentication
	In order to protect my application from unauthorized users
	As a system owner
	I want to require users to login with their username and password to authenticate who they are and only those who are authorized

Scenario: Successful Login
	Given I enter a valid username and password
	When I login
	Then I should be taken to the home page
