Feature: CreateNewProduct

Background:
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When Artwork "TestArtWork2" is uploaded then delete from gallery
	And I select "Create New Product" menu with "" submenu
	Then I should be navigated to "Design" page
	When I select "bags" product category type with "Handbags" sub category type
	And Verify product subcategory page title should be "Handbags"
	And I select "Tote Bag" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	And Verify "Preview" button should be disabled
	And Verify "Launch Product" button should be disabled

@Ignore
@OnlyForWindows
@Regression
Scenario: Upload a new artwork and delete it
	When I Click "Upload Artwork" button and upload artwork
	Then Verify dialogue box page heading name should be "Name your artwork"
	When I name my design as "TestArtWork2"
	And I Click on "Save" Button
	Then Verify artwork should be uploaded successfully
	And Verify "Launch Product" button should be enabled
	When I am on the page "Home"
	And I Click on "gallery" tab button
	Then I should be navigated to "Gallery" page
	And Verify page heading name should be "Gallery"
	And Verify uploaded artwork should be displayed on design page
	When I select that artwork
	Then Verify "Create new product" button should be displayed
	When I Click on "Edit" Button
	And Verify Delete icon should be displayed and click
	Then Verify selected item should be deleted successfully

@Regression
Scenario: Edit uploaded artwork
	When I click "Artwork1" edit button
	Then Verify dialogue box page heading name should be "Name your artwork"
	When I name my design as "Artwork1"
	And I select "Medium" option and "Medium-Other" tag from dropdowmn
	Then Verify subhead tag should be same for selected tag above tag container
	When I select "Style" option and "Contemporary" tag from dropdowmn
	Then Verify subhead tag should be same for selected tag above tag container
	When I select "Theme" option and "Architecture" tag from dropdowmn
	Then Verify subhead tag should be same for selected tag above tag container
	When I select "Cause" option and "Environment" tag from dropdowmn
	Then Verify subhead tag should be same for selected tag above tag container

@Regression
Scenario: Product edit slider validation on upload artwork page
	When I select "Artwork1" artwork
	And I set product edit slider to "40%"
	Then Verify slider should be slide to the given parameter

@Regression
Scenario: Products list checkboxes validation on Launch page
	When I select "Artwork1" artwork
	Then Verify "Launch Product" button should be enabled
	When I Click on "Launch Product" Button
	Then I should be navigated to "Launch" page
	And Verify active navigation tab text should be "LAUNCH" or "02"
	When I select "Deselect All" list selection option
	Then Verify all checkboxes should be deselected
	Then Verify LAUNCH PRODUCTS button is disabled
	When I select "Select All" list selection option
	Then Verify all checkboxes should be selected
	Then Verify LAUNCH PRODUCTS button is enabled