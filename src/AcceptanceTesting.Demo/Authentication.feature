﻿Feature: Authentication
	As a user
	I want to be able to login
	So that I can use the application

@web
Scenario: Invalid Username and Password
	Given a username of "todd@meinershagen.net"
	And a password of "jjj"
	When I login
	Then I should get an error message of "incorrect password, please try again"
