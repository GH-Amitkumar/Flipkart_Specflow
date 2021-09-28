Feature: Flipkart_automationDemo

@mytag
Scenario: FlipKart_Order_Test
	Given Launch Flipkart Website
	When I click on "cancel" button in "LogIn" page
	Then I should be displayed with "Flipkart Home" page
	When I fill below details in "Flipkart Home" page And I click on "Search" button
		| SearchProduct | ProductItem |
		| Samsung A50   | mobile      |
	Then I should be displayed with "ProductResult" page
	When I click on "SAMSUNG Galaxy A50 (Blue, 64 GB)" link in "ProductResult" page
	Then I should be displayed with "Product" page
	And We should verify with "Samsung Galaxy A50 (Blue 64 GB)" text in "Product" page
	When I click on "Add To Cart" button in "Product" page
    Then I should be displayed with "My Cart" page
	When I click on "PLACE ORDER" button in "My Cart" page
	Then I should be displayed with "Login or Signup" page

