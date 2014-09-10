Feature: Authentication
	In order to protect my application from unauthorized users
	As a system owner
	I want to require users to login with their username and password to authenticate who they are and only those who are authorized

Scenario: Login with Valid Username and Password
	Given I enter a valid username and password
	When I login
	Then I should be taken to the home page with username "Todd Meinershagen" displayed

Scenario: Login with Invalid Username and Password
	Given I enter a invalid username and password
	When I login
	Then I should be taken to the login page with title "Nirvana › Signin" 
	And error message with "incorrect password, please try again" text should be displayed