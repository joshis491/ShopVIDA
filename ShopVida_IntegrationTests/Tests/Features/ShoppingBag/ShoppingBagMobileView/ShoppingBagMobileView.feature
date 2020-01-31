Feature: ShoppingBagMobileView

Background:
	When User input specific dimensions for "Pixel2XL"
	And I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I select "Shopping Bag" menu with "" submenu
	Then Verify page heading name should be "Shopping Bag"

@Regression
Scenario Outline: Add a product in Shopping Bag and remove it from home page mobile view
	When There is any product in bag then delete that
	Then Verify "Your bag is empty" text should be displayed for shopping bag page
	When I click close button
	Then I should be navigated to "Home" page
	When I select "Create New Product" menu with "" submenu
	Then I should be navigated to "Design" page
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	And I select "<subProduct>" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	And Verify "Preview" button should be disabled
	And Verify "Launch Product" button should be disabled
	When I click on product info
	And I set my retail price for product is "100"
	When I Click on "Choose From Gallery" Button
	And I select "Artwork1" artwork
	Then Verify "Launch Product" button should be enabled
	Then Verify "Preview" button should be enabled
	When I Click on "Preview" Button
	And Preview the all images
	When I Click on "Launch Product" Button
	Then I should be navigated to "Launch" page
	And Verify active navigation tab text should be "LAUNCH" or "02"
	And Verify product is live text on launch page
	When I Click on "Skip" Button
	Then I should be navigated to "Sample" page
	Then Verify page heading name should be "Shopping Bag"
	Then Verify "Proceed to checkout" button should be enabled
	And Select the "<size>" size from dropdown
	Then Verify active dropdown text should be "<size>"
	And Verify "<subProduct>" should be shown in line items
	When I am on the page "Home"
	Then Verify product card is shown for "Artwork1" with "<subProduct>" subcategory
	And Remove the product from home page for "Artwork1" with "<subProduct>" subcategory
	And Verify product card is not shown for "Artwork1" with "<subProduct>" subcategory
	When I select "Shopping Bag" menu with "" submenu
	Then Verify page heading name should be "Shopping Bag"
	Then Verify "Proceed to checkout" button should be disabled
	And Verify "Your bag is empty" text should be displayed for shopping bag page

	Examples:
		| category | product | subProduct     | size       |
		| apparel  | Tops    | Sleeveless Top | White / 2X |

@Regression
Scenario: Remove an item from shopping bag using Remove Samples Button mobile view
	When There is no product in bag then add a product
	Then Verify "Proceed to checkout" button should be enabled
	When I click Remove Samples button
	Then Verify "Your bag is empty" text should be displayed for shopping bag page
	And Verify "Proceed to checkout" button should be disabled

@Regression
Scenario: Remove an item from shopping bag using minus Button mobile view
	When There is no product in bag then add a product
	Then Verify "Proceed to checkout" button should be enabled
	When I click Product Minus button
	Then Verify "Your bag is empty" text should be displayed for shopping bag page
	And Verify "Proceed to checkout" button should be disabled

@Regression
Scenario: Verify product plus Button functionality mobile view
	When There is no product in bag then add a product
	Then Verify "Proceed to checkout" button should be enabled
	When I click Product Plus button and verify it

@Regression
Scenario: Add gift box mobile view
	When I Click on " Add Gift Box" Button
	Then Verify Gift box quantity should be updated in grid

@Regression
Scenario: Remove gift box mobile view
	When I Click on " Add Gift Box" Button
	And I click Gift Box Minus button
	Then Verify gift card should be removed from grid

@Regression
Scenario: Gift box plus button validation mobile view
	When I Click on " Add Gift Box" Button
	And I click Gift Box Plus button
	Then Verify Gift box quantity should be updated in grid

@Regression
Scenario: Verify total checkout cost mobile view
	When There is no product in bag then add a product
	Then Verify "Proceed to checkout" button should be enabled
	When I Click on " Add Gift Box" Button
	Then Verify total checkout cost