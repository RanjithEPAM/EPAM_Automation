Feature: Parallel

A short summary of the feature

@tag1
Scenario: Registration
	Given I launch the url
	When I navigate to registration screen
	And the register details are entered
	Then the details should be displayed at bottom
