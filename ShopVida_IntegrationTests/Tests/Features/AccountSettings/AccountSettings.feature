Feature: Account Settings

Background:
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I select "Account" menu with "Account Settings" submenu
	Then I should be navigated to "Settings" page
	And Verify page heading name should be "Settings"
	And Verify "Save Signature" button should be disabled

@ENG-533
@deleteScenarioLoadedData
@Regression
Scenario: Update profile details
	Given I get Settings data from file "UpdateProfileDetails.json"
	When I select "GIFTCARD" payment preferences radio button
	#And I Uploaded all the required photos
	And Draw a new signature on canvas
	#Then Verify "Save Signature" button should be enabled
	When I fill account settings form:
	And I Click Save Button
	And I am on the page "Home"
	And I select "Account" menu with "Account Settings" submenu
	Then Verify account settings page contains correct data

@Regression
Scenario: Update profile details validation
	When I clear and input values and verify validation messages

@Regression
Scenario: Deactivate link content validation
	When I click Deactivate Account link
	Then Verify the deactive account content in dialogue box