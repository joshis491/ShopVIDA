﻿Feature: Logout
Description : Logout user and check if the functionality works

@Regression
Scenario: Successfully Logout
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I Click SignOut Button
	Then I should be able to see login popup/dialog box generated by URL
	And Verify the text "Click your email below to login" on login popup 