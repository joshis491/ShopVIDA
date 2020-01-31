Feature: CreateNewProductValidations

Background:
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I select "Create New Product" menu with "" submenu
	Then I should be navigated to "Design" page

@Regression
Scenario: Validate close icon functionality on design page
	When I click close icon
	Then I should be navigated to "Home" page

@Regression
Scenario Outline: Validate BACK link functionality on subcatagory page
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	When I click "BACK" link on subcatagory page
	Then Verify "<category>" product types title should be shown

	Examples:
		| category | product |
		| home     | Pillows |

@Regression
Scenario Outline: Validate BACK button functionality on Upload Artwork page
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	And I select "<subCatagory>" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	When I Click on "Back" Button
	Then Verify "<category>" product types title should be shown

	Examples:
		| category | product | subCatagory   |
		| home     | Pillows | Square Pillow |

@Regression
Scenario Outline: Select product by subcatagory type
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	And I select "<subCatagory>" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	And Verify "Launch Product" button should be disabled

	Examples:
		| category | product    | subCatagory |
		| apparel  | Athleisure | Yoga Mat    |

@Regression
Scenario: Select product by catagory type
	When I click "accessories" product types title and verify it
	And Verify product subcategory page title should be "Accessories"
	And Verify active footer menu should be "Accessories"
	When I select "Jewelry" subcategory image
	And Verify product subcategory page title should be "Jewelry"
	When I select "Round Statement Ring" subcategory image
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	And Verify "Launch Product" button should be disabled

@Regression
Scenario: Validate footer menu navigation on subcatagory page
	When I click "accessories" product types title and verify it
	And Verify product subcategory page title should be "Accessories"
	And Verify active footer menu should be "Accessories"
	When I click "Scarves" footer menu
	And Verify active footer menu should be "Scarves"
	When I click "Bags" footer menu
	And Verify active footer menu should be "Bags"
	When I click "Apparel" footer menu
	And Verify active footer menu should be "Apparel"
	When I click "Home" footer menu
	And Verify active footer menu should be "Home"

@Regression
Scenario: Validate product catagory tab navigation on Launch page
	When I click "accessories" product types title and verify it
	And Verify product subcategory page title should be "Accessories"
	And Verify active footer menu should be "Accessories"
	When I select "Jewelry" subcategory image
	And Verify product subcategory page title should be "Jewelry"
	When I select "Round Statement Ring" subcategory image
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	And Verify "Launch Product" button should be disabled
	When I select "Artwork1" artwork
	Then Verify "Launch Product" button should be enabled
	When I Click on "Launch Product" Button
	Then I should be navigated to "Launch" page
	And Verify active navigation tab text should be "LAUNCH" or "02"
	And Product catagory active tab should be "Accessories"
	And Verify products count should be same as transparent badge for "Accessories" tab
	When I click "Scarves" Product catagory tab
	Then Product catagory active tab should be "Scarves"
	And Verify products count should be same as transparent badge for "Scarves" tab
	When I click "Bags" Product catagory tab
	Then Product catagory active tab should be "Bags"
	And Verify products count should be same as transparent badge for "Bags" tab
	When I click "Apparel" Product catagory tab
	Then Product catagory active tab should be "Apparel"
	And Verify products count should be same as transparent badge for "Apparel" tab
	When I click "Home Decor" Product catagory tab
	Then Product catagory active tab should be "Home Decor"
	And Verify products count should be same as transparent badge for "Home Decor" tab

@Regression
Scenario: Test
	When I select "Handbags" product types sub-category