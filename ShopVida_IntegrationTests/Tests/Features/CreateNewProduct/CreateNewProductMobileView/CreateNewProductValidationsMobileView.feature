Feature: CreateNewProductValidationsMobileView

Background:
	When User input specific dimensions for "Pixel2XL"
	And I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I select "Create New Product" menu with "" submenu
	Then I should be navigated to "Design" page

@Regression
Scenario: Validate close icon functionality on design page mobile view
	When I click close icon
	Then I should be navigated to "Home" page

@Regression
Scenario Outline: Validate BACK link functionality on subcatagory page mobile view
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	When I click "BACK" link on subcatagory page
	Then Verify "<category>" product types title should be shown

	Examples:
		| category | product |
		| home     | Pillows |

@Regression
Scenario Outline: Validate Change Product button functionality on Upload Artwork page mobile view
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	And I select "<subCatagory>" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	When I Click on "Choose From Gallery" Button
	And I select "Artwork1" artwork
	When I Click on "Change Product" Button
	Then Verify "<category>" product types title should be shown

	Examples:
		| category | product | subCatagory   |
		| home     | Pillows | Square Pillow |

@Regression
Scenario Outline: Select product by subcatagory type mobile view
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	And I select "<subCatagory>" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	When I Click on "Choose From Gallery" Button
	And I select "Artwork1" artwork
	Then Verify "Launch Product" button should be displayed

	Examples:
		| category | product    | subCatagory |
		| apparel  | Athleisure | Yoga Mat    |