Feature: StorefrontMobileView

Background:
	When User input specific dimensions for "Pixel2XL"
	And I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |

@Regression 
Scenario: View storefront mobile view
	When I select "Account" menu with "Account Settings" submenu
	And I select "Storefront" menu with "View Storefront" submenu
	Then I am on the page "Storefront"

@Regression
Scenario: Verify view sample storefront link mobile view
	When I select "Storefront" menu with "Upgrade to a Premium Storefront" submenu
	Then Verify dialogue box page heading name should be "UPGRADE TO A PREMIUM STOREFRONT"
	And Verify "Upgrade Today" button should be displayed
	When I click "View Sample Storefront" link
	Then I am on the page "StorefrontSample"

@Regression
Scenario: Verify upgrade today button (Become a premium member) mobile view
	When I select "Storefront" menu with "Upgrade to a Premium Storefront" submenu
	Then Verify dialogue box page heading name should be "UPGRADE TO A PREMIUM STOREFRONT"
	And Verify "Upgrade Today" button should be displayed
	When I Click on "Upgrade Today" Button
	Then I am on the page "PremiumStorefront"
	Then Verify page header name should be "Premium Storefront"
	And Verify "Choose Price Plan" button should be displayed
	When I select "$5" purchase amount
	And I Click on "Become a premium member" Button
	Then I am on the page "PremiumSubscription"

@Regression
Scenario: Verify upgrade today button mobile view
	When I select "Storefront" menu with "Upgrade to a Premium Storefront" submenu
	Then Verify dialogue box page heading name should be "UPGRADE TO A PREMIUM STOREFRONT"
	And Verify "Upgrade Today" button should be displayed
	When I Click on "Upgrade Today" Button
	Then I am on the page "PremiumStorefront"
	Then Verify page header name should be "Premium Storefront"
	And Verify "Choose Price Plan" button should be displayed
	When I select "$10" purchase amount
	Then Verify purchase amount tab should be shown as selected
	And Verify the total amount for selected plan

@Regression
Scenario: Upgrade today button payment validation mobile view
	When I select "Storefront" menu with "Upgrade to a Premium Storefront" submenu
	Then Verify dialogue box page heading name should be "UPGRADE TO A PREMIUM STOREFRONT"
	And Verify "Upgrade Today" button should be displayed
	When I Click on "Upgrade Today" Button
	Then I am on the page "PremiumStorefront"
	Then Verify page header name should be "Premium Storefront"
	And Verify "Choose Price Plan" button should be displayed
	When I select "$10" purchase amount
	Then Verify purchase amount tab should be shown as selected
	And Verify the total amount for selected plan
	When I Click on "Choose Price Plan" Button
	Then Verify "Add Card" button should be displayed
	When I get Storefront data from file "StorefrontDetails.json"
	Then I fill payment form and verify validation messages