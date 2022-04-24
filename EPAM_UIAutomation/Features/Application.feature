Feature: Validation of ToolsQA Site

@Smoke
Scenario: Working with dropdowns in ToolsQA site
	Given I launch the ToolsQA url
	When I select Elements option
	And Navigating to Select Menu screen
	Then user should be able to select value from drop downs

@Regression
Scenario: Validation of Registration Screen
	Given I launch the ToolsQA url
	When I navigate to Registration screen
	And the user details are submitted as
		| Field            | Value              |
		| Name             | <Name>             |
		| Email            | <Email>            |
		| CurrentAddress   | <CurrentAddress>   |
		| PermanentAddress | <PermanentAddress> |
	Then the submitted details should be displayed in the same screen
	And able to collect all links in webpage

Examples:
	| TestCaseID | Name    | Email             | CurrentAddress | PermanentAddress |
	| 001        | User001 | user001@gmail.com | AddressUser1   | TAddressUser1    |
	| 002        | User002 | user002@gmail.com | AddressUser2   | TAddressUser2    |
	| 003        | User003 | user003@gmail.com | AddressUser3   | TAddressUser3    |