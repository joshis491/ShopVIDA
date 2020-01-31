Feature: NavigationMobileView

Background:
	When User input specific dimensions for "Pixel2XL"
	And I should already logged in with credentials
		| email                 | password  | buttonName | landedScreenName |
		| testaccount@gmail.com | Test@1234 | LOG IN     | Products         |

Scenario Outline: Validate main menu navigation links mobile view
	When I click "<menu>" and "<submenu>"
	Then I navigated on page "<page>"

	Examples:
		| menu                  | submenu              | page               |
		| Create New Product    |                      | Design             |
		| Marketing Tools       | Email Marketing Tool | EmailMarketing     |
		| Sales                 | Sales Dashboard      | Dashboard          |
		| Account               | Account Settings     | Settings           |
		| Design Gallery        |                      | DesignGallery      |
		| Learn More about VIDA |                      | LearnMoreAboutVIDA |
		| Give Us Feedback      |                      | Feedback           |

Scenario Outline: Verify main menu navigation links mobile view
	When I click "<menu>" and "<submenu>"
	Then I am on the page "<page>"

	Examples:
		| menu            | submenu                   | page                    |
		| Marketing Tools | Editorial Photography     | EditorialPhotography    |
		| Marketing Tools | Premium Subscription      | PremiumSubscription     |
		| Marketing Tools | Artist Ambassador Program | ArtistAmbassadorProgram |
		| Marketing Tools | Tips & Resources          | TipsAndResources        |
		| Account         | Order History             | OrderHistory            |
		| Help Center     |                           | HelpCenter              |

@Regression
Scenario Outline: Verify social media icons navigation mobile view
	When I click "<icon>" social media icon
	Then I am on the page "<page>"

	Examples:
		| icon      | page      |
		| twitter   | Twitter   |
		| facebook  | Facebook  |
		| instagram | Instagram |
		| pinterest | Pinterest |
		| youtube   | YouTube   |

@Regression
Scenario Outline: Verify About list items navigation on lower footer mobile view
	When I click "<listItem>" lower footer link
	Then I am on the page "<page>"

	Examples:
		| listItem                  | page                    |
		| Artist Ambassador Program | ArtistAmbassadorProgram |
		| Become a Premium Member   | PremiumSubscription     |
		| Shipping Times            | ShippingTimes           |
		| Artist Terms & Conditions | TermsAndConditions      |
		| VIDA Reviews              | Reviews                 |
		| VIDA Blog                 | Blogs                   |

@Regression
Scenario Outline: Verify Privacy Policy navigation on lower footer mobile view
	When I click "<listItem>" lower footer link
	Then I navigated on page "<page>"

	Examples:
		| listItem       | page          |
		| Privacy Policy | PrivacyPolicy |