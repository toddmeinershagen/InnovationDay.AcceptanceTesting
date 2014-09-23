# @autoLogin
Feature: AddingTasks
	In order to keep track of my tasks
	As a todo list user
	I want to be able to add tasks

Background:
	Given I am logged in

Scenario: Add a task
	Given I enter info for a new task
	| Field | Value                     |
	| Name  | Test Task                 |
	| Note  | This is a test task note. |
	When I save the task
	Then the task with title "Test Task" should appear in my list of tasks

@ignore
Scenario:  Cancel adding a task
	Given I enter info for a new task
	| Field | Value                     |
	| Name  | Test Task                 |
	| Note  | This is a test task note. |
	When I cancel the task
	Then the task with title "Test Task" should not appear in my list of tasks