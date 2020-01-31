﻿Feature: LoginAction
Description : Check if the Login action and validation functionality works

Background:
	Given I launch the application
	Then I should be able to see login popup/dialog box generated by URL
	And I verify the welcome header title text
	And Verify current navigation tab should be "Log In"

@Smoke @positive
Scenario Outline: Successful Login with Valid Credentials
	When I input specific login credentials "<email>" and "<password>"
	And I Click Login Button
	Then I should be navigated to "Home" page
	And Verify page heading name should be "Products"
	And I see "Create new product" text

	Examples:
		| email                 | password  |
		| testaccount@gmail.com | Test@1234 |

@negative
Scenario: Unsuccessful Login With Invalid Credentials
	When I Entered Invalid Login Credentials
		| email                    | password  |
		| softwaretester@gmail.com | Test@123! |
	And I Click Login Button
	Then Error message with text "INCORRECT EMAIL OR PASSWORD." is displayed
	And Login should fail
	But Relogin options should be available

Scenario: Login with blank value validation
	When I clear the login credentials
	And I Click Login Button
	Then I see login page error message