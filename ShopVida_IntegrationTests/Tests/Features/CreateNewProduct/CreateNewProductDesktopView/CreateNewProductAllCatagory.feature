Feature: CreateNewProductAllCatagory

@ENG-544
Scenario Outline: Create new product for all catagories
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I select "Create New Product" menu with "" submenu
	Then I should be navigated to "Design" page
	When I select "<category>" product category type with "<product>" sub category type
	And Verify product subcategory page title should be "<product>"
	And I select "<shopifyProductType>" subcategory type
	Then I navigated to a page where side bar header should be "Design Your Product"
	And Verify active navigation tab text should be "DESIGN" or "01"
	And Verify "Preview" button should be disabled
	And Verify "Launch Product" button should be disabled
	When I click on product info
	Then Verify subcategory type below side bar header should be "<shopvidaProductType>"
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
	And Verify active navigation tab text should be "SAMPLE" or "03"
	Then I should be navigated to "Sample" page
	Then Verify page heading name should be "Shopping Bag"
	When I click Remove Samples button
	When I am on the page "Home"
	Then Verify product card is shown for "Artwork1" with "<shopvidaProductType>" subcategory
	And Remove the product from home page for "Artwork1" with "<shopvidaProductType>" subcategory
	And Verify product card is not shown for "Artwork1" with "<shopvidaProductType>" subcategory

	Examples:
		| category    | product          | shopifyProductType                  | shopvidaProductType                 |
		| scarves     | Cotton           | Natural Cotton Scarf                | Natural Cotton Scarf                |
		| scarves     | Silk             | Mini Square Scarf                   | Mini Square Scarf                   |
		| scarves     | Merino Wool      | Oversized Merino Wool               | Oversized Merino Wool               |
		| scarves     | Cashmere         | 100% Cashmere Scarf                 | 100% Cashmere Scarf                 |
		| scarves     | Infinity         | Infinity Eco Scarf                  | Infinity Eco Scarf                  |
		| scarves     | Infinity         | Natural Cotton Scarf                | Natural Cotton Scarf                |
		| bags        | Studio Bag       | Studio Bag                          | Studio Bag                          |
		| bags        | Handbags         | Statement Bag                       | Statement Bag                       |
		| bags        | Handbags         | Tote Bag                            | Tote Bag                            |
		| bags        | Handbags         | Studio Bag                          | Studio Bag                          |
		| bags        | Clutches         | Leather Statement Clutch            | Leather Statement Clutch            |
		| bags        | Clutches         | Statement Clutch                    | Statement Clutch                    |
		| bags        | Pouches          | Foldaway Tote                       | Foldaway Tote                       |
		| bags        | Pouches          | Carry-All Pouch                     | Carry-All Pouch                     |
		| apparel     | Tees             | Modern Tee                          | Modern Tee                          |
		| apparel     | Tees             | Unisex Tee - Front Print            | Unisex Tee - Front Print            |
		| apparel     | Tops             | Modern Eco Sweatshirt               | Modern Eco Sweatshirt               |
		| apparel     | Tops             | Essential Top                       | Essential Top                       |
		| apparel     | Tops             | Sleeveless Top                      | Sleeveless Top                      |
		| apparel     | Leggings         | Leggings                            | Leggings                            |
		| apparel     | Wraps            | Sheer Wrap                          | Sheer Wrap                          |
		| apparel     | Wraps            | Cocoon Wrap                         | Cocoon Wrap                         |
		| apparel     | Wraps            | Wool Poncho Wrap                    | Wool Poncho Wrap                    |
		| apparel     | Athleisure       | Modern Eco Sweatshirt               | Modern Eco Sweatshirt               |
		| apparel     | Athleisure       | Infinity Eco Scarf                  | Infinity Eco Scarf                  |
		| apparel     | Athleisure       | Leggings                            | Leggings                            |
		| apparel     | Athleisure       | Yoga Mat                            | Yoga Mat                            |
		| accessories | Active           | Water Bottle                        | Water Bottle                        |
		| accessories | Active           | Yoga Mat                            | Yoga Mat                            |
		| accessories | Active           | Studio Bag                          | Studio Bag                          |
		| accessories | Umbrellas        | Foldable Umbrella                   | Foldable Umbrella                   |
		| accessories | Travel + Tech    | Leather Accent Tag                  | Leather Accent Tag                  |
		| accessories | Travel + Tech    | Leather Passport Case               | Leather Passport Case               |
		| accessories | Wallets          | Leather Slimfold Wallet             | Leather Slimfold Wallet             |
		| accessories | Wallets          | Leather Zip-Around Wallet           | Leather Zip-Around Wallet           |
		| accessories | Jewelry          | Round Statement Ring                | Round Statement Ring                |
		| accessories | Jewelry          | Oversized Round Pendant             | Oversized Round Pendant             |
		| accessories | Jewelry          | Oversized Square Pendant            | Oversized Square Pendant            |
		| accessories | Jewelry          | Oversized Statement Pendant         | Oversized Statement Pendant         |
		| accessories | Men's            | Men's Cotton Pocket Square          | Men's Cotton Pocket Square          |
		| accessories | Men's            | Men's Silk Pocket Square            | Men's Silk Pocket Square            |
		| accessories | Men's            | Tie                                 | Tie                                 |
		| home        | Pillows          | Square Pillow                       | Square Pillow                       |
		| home        | Pillows          | Oblong Pillow                       | Oblong Pillow                       |
		| home        | Kitchen & Dining | Water Bottle                        | Water Bottle                        |
		| home        | Kitchen & Dining | Classic Mug                         | Classic Mug                         |
		| home        | Kitchen & Dining | Tea Towel Set of 2                  | Tea Towel Set of 2                  |
		| home        | Kitchen & Dining | Statement Mug                       | Statement Mug                       |
		| home        | Kitchen & Dining | Bamboo Coaster Set - Single Artwork | Bamboo Coaster Set - Single Artwork |
		| home        | Kitchen & Dining | Bamboo Coaster Set - Mixed Artwork  | Bamboo Coaster Set - Mixed Artwork  |
		| home        | Kitchen & Dining | Table Runner                        | Table Runner                        |
		| home        | Home Decor       | Ornament                            | Ornament                            |
		| home        | Stationery       | Leather Journal                     | Leather Journal                     |
		| home        | Stationery       | Greeting Cards Set                  | Greeting Cards Set                  |
		| scarves     | Modal            | Modal Scarves                       | 100% Modal                          |
		| scarves     | Silk             | Cashmere Silk Scarf                 | Cashmere Silk                       |
		| scarves     | Silk             | Silk Square Scarf                   | Silk Square                         |
		| accessories | Jewelry          | Charm Bracelet                      | Square Beveled Charm Bracelet       |
		| accessories | Travel + Tech    | iPhone Case                         | Iphone Cover                        |
		| apparel     | Tees             | Boatneck Boyfriend Tee              | Boatneck Boyfriend Tee              |
		| apparel     | Tees             | Unisex Tee - Full Print             | Unisex Tee - Print All-over         |
		| apparel     | Tops             | Printed Racerback Top               | Racerback                           |
		| apparel     | Tops             | Sleeveless Knit                     | Sleeveless Knit Top                 |
		| apparel     | Tops             | Women's Crewneck Sweatshirt         | Sweatshirt                          |
		| apparel     | Leggings         | Yoga Capri Pants                    | Capri                               |
		| apparel     | Athleisure       | Yoga Capri Pants                    | Capri                               |
		| apparel     | Athleisure       | Printed Racerback Top               | Racerback                           |
		| apparel     | Athleisure       | Women's Crewneck Sweatshirt         | Sweatshirt                          |
		| home        | Kitchen & Dining | Oven Mitt & Potholder               | Oven Mitt Potholder                 |
		| home        | Kitchen & Dining | Oblong Glass Tray                   | Glass Tray - Oblong                 |
		| home        | Kitchen & Dining | Square Glass Tray                   | Glass Tray - Square                 |
		| home        | Kitchen & Dining | Round Glass Tray                    | Glass Tray - Round                  |
		| home        | Kitchen & Dining | Placemat Set                        | Placemat Set Round                  |
		| home        | Kitchen & Dining | Placemat Set                        | Placemat Set Rectangle              |
		| home        | Kitchen & Dining | Napkin Set                          | Napkins                             |
		| home        | Home Decor       | Wood Wall Art - 8x24                | Wood 8x24                           |
		| home        | Home Decor       | Wood Wall Art - Set of 3            | Wood Wall Art 8x24 Set of 3         |
		| home        | Home Decor       | Wood Wall Art - 12x12               | Wood Wall Art 12x12                 |
		| home        | Home Decor       | Wood Wall Art - Set of 4            | Wood Wall Art Set of 4              |
		| home        | Home Decor       | Wood Wall Art - 30x20               | Wood Wall Art 30x20                 |
		| home        | Home Decor       | Square Glass Tray                   | Glass Tray - Square                 |
		| scarves     | Cashmere         | Cashmere Silk Scarf                 | Cashmere Silk                       |
		| home        | Home Decor       | Round Glass Tray                    | Glass Tray - Round                  |