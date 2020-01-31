Feature: DesignGallery

Background:
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |

@Regression
Scenario: Select a product to reuse design
	When I select "Design Gallery" menu with "" submenu
	Then I should be navigated to "DesignGallery" page
	And Verify page heading name should be "Gallery"
	When There is no design in gallery then add a design
	And I select "Artwork1" desgin
	Then Verify "Create new product" button should be displayed
	When I Click on "Create new product" Button
	Then I should be navigated to "Design" page
	And Verify the header text "SELECT A PRODUCT TO REUSE DESIGN"
	When I select "bags" product category type with "Handbags" sub category type
	And Verify product subcategory page title should be "Handbags"
	And I select "Tote Bag" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	Then Verify "Launch Product" button should be enabled
	When I click on product info
	And I set my retail price for product is "100"
	When I Click on "Launch Product" Button
	Then I should be navigated to "Launch" page
	And Verify active navigation tab text should be "LAUNCH" or "02"
	And Verify product is live text on launch page
	When I Click on "Skip" Button
	And Verify active navigation tab text should be "SAMPLE" or "03"
	Then I should be navigated to "Sample" page
	Then Verify page heading name should be "Shopping Bag"
	When I am on the page "Home"
	Then Verify product card is shown for "Artwork1" with "Tote Bag" subcategory
	And Remove the product from home page for "Artwork1" with "Tote Bag" subcategory
	And Verify product card is not shown for "Artwork1" with "Tote Bag" subcategory

@Regression
Scenario: Promote a design
	Then Remove the product from home page for "Artwork1" with "Tote Bag" subcategory
	When Add a "bags" with "Handbags" and "Tote Bag"
	Then Verify product card is shown for "Artwork1" with "Tote Bag" subcategory
	And Click on Promote for "Artwork1" with "Tote Bag" subcategory
	Then Verify "Next" button should be displayed
	And Active step text should be "01"
	When I selected "Accessories" as promoted on with date "2020-01-11"
	And I Click on "Next" Button
	Then Active step text should be "02"
	When I select the plan "$45"
	And I Click on "Next" Button
	Then Active step text should be "03"
	When I get Storefront data from file "StorefrontDetails.json"
	Then I fill payment form and verify validation messages
	When I am on the page "Home"
	Then Remove the product from home page for "Artwork1" with "Tote Bag" subcategory