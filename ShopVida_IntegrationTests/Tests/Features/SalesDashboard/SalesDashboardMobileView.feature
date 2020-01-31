Feature: SalesDashboardMobileView

Background:
	When User input specific dimensions for "Pixel2XL"
	And I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	Then Remove the product from home page for "<artwork>" with "<product>" subcategory
	When I select "Sales" menu with "Sales Dashboard" submenu
	Then Verify page heading name should be "Sales Dashboard"

@Regression
Scenario: Sales dashboard date validation mobile view
	When I select start date "2019/01/12" and end date "2020/01/14"
	Then Verify the selected dated in calender picker

@Regression
Scenario Outline: Relaunch the product to the collection and delete it mobile view
	When I select "This Month" from calender picker
	And Relaunch the "<artwork>" with "<product>" type
	Then Verify status should changed to "Live" for "<product>" product
	When I Remove the products with "<product>" type
	Then Verify status should changed to "Removed" for "<product>" product

	Examples:
		| artwork  | product  |
		| Artwork1 | Leggings |

@Regression
Scenario Outline: Relaunch the product and remove it from home page mobile view
	When I select "This Month" from calender picker
	And Relaunch the "<artwork>" with "<product>" type
	Then Verify status should changed to "Live" for "<product>" product
	When I am on the page "Home"
	Then Verify product card is shown for "<artwork>" with "<product>" subcategory
	And Remove the product from home page for "<artwork>" with "<product>" subcategory
	And Verify product card is not shown for "<artwork>" with "<product>" subcategory
	When I select "Sales" menu with "Sales Dashboard" submenu
	And I select "Today" from calender picker
	Then Verify status should changed to "Removed" for "<product>" product

	Examples:
		| artwork  | product  |
		| Artwork1 | Leggings |

@Ignore
Scenario Outline: Limit items mobile view
	When I select "This Month" from calender picker
	And I select "<Value>" value in Limit items filter
	Then There should be <Value> results on resources list

	Examples:
		| Value | artwork  | product  |
		| 100   | Artwork1 | Leggings |