﻿Feature: AccountSettingsMobileView

Background:
	When User input specific dimensions for "Pixel2XL" 
	And I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	And I select "Account" menu with "Account Settings" submenu
	Then I should be navigated to "Settings" page
	And Verify page heading name should be "Settings"
	And Verify "Save Signature" button should be disabled

@ENG-533
@Regression
Scenario: Update profile details mobile view
	Given I get Settings data from file "UpdateProfileDetails.json"
	When I fill account settings form:
	And I select "GIFTCARD" payment preferences radio button
	And I Uploaded all the required photos
	And Draw a new signature on canvas
	Then Verify "Save Signature" button should be enabled

@Regression
Scenario: Update profile details validation mobile view
	When I clear and input values and verify validation messages

@Regression
Scenario: Deactivate link content validation mobile view
	When I click Deactivate Account link
	Then Verify the deactive account content in dialogue box