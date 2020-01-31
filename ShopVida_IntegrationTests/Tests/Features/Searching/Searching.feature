Feature: Searching

@ENG-591
@Regression
Scenario Outline: Search a product and add it to bag
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I click on search button on home page
	And Input the search data as "<artwork>"
	Then Verify all search result details have "<artwork>"
	When I Select "<artwork>" and "<product>" from search details
	Then Verify "ADD TO BAG" button should be displayed
	And Verify display "<artwork>" and "<product>" name should be correct
	When I Set the quantity as "1"
	And Preview the images for ProductModal slider
	And I Click on "ADD TO BAG" Button
	And I am on the page "Home"
	When I select "Shopping Bag" menu with "" submenu
	Then Verify page heading name should be "Shopping Bag"

	Examples:
		| artwork  | product  |
		| Artwork1 | Yoga Mat |