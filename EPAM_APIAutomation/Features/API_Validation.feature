Feature: Validation of API requests in REQRES

A short summary of the feature

@ignore
Scenario: Validation of GET Request for retrieving users list
	Given I have a GET request for ReqRes API
	When I send the GET request for ReqRes API
	Then I receive the response
	And the status code should be 200
@Smoke
Scenario: Validation of POST Request for creating user
	Given I have a POST request for ReqRes API
	When I send the POST request for ReqRes API as
		| Field | Value  |
		| Name  | <Name> |
		| Job   | <Job>  |
	Then the new user should be created with 201 status code
Examples:
	| TestcaseID | Name  | Job     |
	| 101        | Kevin | Teacher |
	| 102        | Chris | Dentist |
@Smoke
Scenario: Validation of PUT Request for updating user details
	Given I have a PUT request for ReqRes API
	When I send the PUT request for ReqRes API as
		| Field | Value  |
		| Name  | <Name> |
		| Job   | <Job>  |
	Then the given user should be úpdated with 200 status code
Examples:
	| TestcaseID | Name  | Job     |
	| 101        | Kevin | Teacher |
	| 102        | Chris | Dentist |
@Smoke
Scenario: Validation of Delete Request for deleting user details
	Given I have a DELETE request for ReqRes API
	When I send the DELETE request for ReqRes API as
		| Field | Value  |
		| Name  | <Name> |
		| Job   | <Job>  |
	Then the given user should be deleted with 204 status code
Examples:
	| TestcaseID | Name  | Job     |
	| 101        | Kevin | Teacher |
	| 102        | Chris | Dentist |