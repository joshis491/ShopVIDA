Feature: ShoppingBagCheckoutValidation

Background:
	Given I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |
	When I select "Shopping Bag" menu with "" submenu
	Then Verify page heading name should be "Shopping Bag"
	When There is no product in bag then add a product
	Then Verify "Proceed to checkout" button should be enabled
	When I Click on "Proceed to checkout" Button
	Then I'm on "WHOLESALE" payment page

@Regression
Scenario: Perform checkout the product in shopping bag
	Then Verify current active header tab should be "Information"
	When I get Shopping Bag Payments data from file "ShoppingBagPayments.json"
	And I fill shopping bag checkout form information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	And Verify current active header tab should be "Shipping"
	When I select "Express Shipping [Intl] - 1 Week" shipping method
	And I Click Continue to payment Button
	Then I'm on "payment_method" payment page
	And Verify current active header tab should be "Payment"

@Regression
Scenario: Shopping bag checkout page validation
	Then Verify the validation messages for checkout page:
		| Country1      | GiftCardCode |
		| United States | Test         |

@Regression
Scenario: See production times page validation
	Then Verify current active header tab should be "Information"
	When I get Shopping Bag Payments data from file "ShoppingBagPayments.json"
	And I fill shopping bag checkout form information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	And Verify current active header tab should be "Shipping"
	When I click "See production times" link
	Then I am on the page "SeeProductionTimes"

@Regression
Scenario: Validate shopping bag checkout all steps navigation
	Then Verify current active header tab should be "Information"
	When I get Shopping Bag Payments data from file "ShoppingBagPayments.json"
	And I fill shopping bag checkout form information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	And Verify current active header tab should be "Shipping"
	When I select "Express Shipping [Intl] - 1 Week" shipping method
	And I Click Continue to payment Button
	Then I'm on "payment_method" payment page
	And Verify current active header tab should be "Payment"
	When I Click Return to shipping Button
	Then I'm on "shipping_method" payment page
	When I Click Return to information Button
	Then I'm on "contact_information" payment page
	When I click active header tab "Shipping"
	Then Verify current active header tab should be "Shipping"
	When I click active header tab "Information"
	Then Verify current active header tab should be "Information"
	When I click active header tab "Payment"
	Then Verify current active header tab should be "Payment"
	When I click active header tab "Shipping"
	Then Verify current active header tab should be "Shipping"

@Regression
Scenario: Edit shopping bag checkout step name shipping
	Then Verify current active header tab should be "Information"
	When I get Shopping Bag Payments data from file "ShoppingBagPayments.json"
	And I fill shopping bag checkout form information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	And Verify current active header tab should be "Shipping"
	When I click the "Change contact information" change button for "shipping" step
	Then I'm on "contact_information" payment page
	When I fill data for "Contact Info" in checkout Information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	Then Verify data should be updated for "Change contact information" in shipping step
	When I click the "Change shipping address" change button for "shipping" step
	Then I'm on "contact_information" payment page
	When I fill data for "Shipping address" in checkout Information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	Then Verify data should be updated for "Change shipping address" in shipping step

@Regression
Scenario: Edit shopping bag checkout step name payment
	Then Verify current active header tab should be "Information"
	When I get Shopping Bag Payments data from file "ShoppingBagPayments.json"
	And I fill shopping bag checkout form information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	And Verify current active header tab should be "Shipping"
	When I Click Continue to payment Button
	Then I'm on "payment_method" payment page
	And Verify current active header tab should be "Payment"
	When I click the "Change contact information" change button for "payment" step
	Then I'm on "contact_information" payment page
	When I fill data for "Contact Info" in checkout Information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	When I Click Continue to payment Button
	Then I'm on "payment_method" payment page
	Then Verify data should be updated for "Change contact information" in shipping step
	When I click the "Change shipping address" change button for "payment" step
	Then I'm on "contact_information" payment page
	When I fill data for "Shipping address" in checkout Information step
	And I Click Continue to shipping Button
	Then I'm on "shipping_method" payment page
	When I Click Continue to payment Button
	Then I'm on "payment_method" payment page
	Then Verify data should be updated for "Change shipping address" in shipping step
	When I click the "Change shipping method" change button for "payment" step
	Then I'm on "shipping_method" payment page
	When I select "Express Shipping [Intl] - 1 Week" shipping method
	And I Click Continue to payment Button
	Then I'm on "payment_method" payment page
	Then Verify data should be updated for "Change shipping method" in shipping step
	When I select "Use a different billing address" billing address
	When I fill billing address form