@TFL
Feature: JourneyPlanner
	As a Senior Test Analyst,
	I want the ability to validate Journey Planner widget in TFL website

Background:
	Given I launch the chrome browser and maximize it

Scenario: Validation of valid journey using plan a journey widget
	Given I launch the TFL site
	And I enter the source and destination locations in TFL site
		| Source  | Destination     |
		| Barking | North Greenwich |
	When I click Plan my Journey button
	Then The displayed journey details are validated

Scenario: Validation of an invalid journey using plan a journey widget
	Given I launch the TFL site
	And I enter the source and destination locations in TFL site
		| Source   | Destination |
		| !@#$1234 | !@#$1234    |
	When I click Plan my Journey button
	Then An error message is displayed
		| ErrorMessage                                                                |
		| Journey planner could not find any results to your search. Please try again |

Scenario: Validation of journey planner widget when no locations are entered
	Given I launch the TFL site
	When I click Plan my Journey button without proving From and To locations
	Then Appropriate error messages are displayed in journey planner widget

Scenario: Validation of edit journey option in journey results page
	Given I launch the TFL site
	And I enter the source and destination locations in TFL site
		| Source  | Destination     |
		| Barking | North Greenwich |
	And I click Plan my Journey button
	And The journey details are displayed
	When I select Edit Journey option in journey results page
	And I update the From location as "Canary Wharf"
	And I press Update Journey button
	Then The updated journey details are displayed

Scenario: Validation of Recents tab in the journey planner widget
	Given I launch the TFL site
	And I enter the source and destination locations in TFL site
		| Source  | Destination     |
		| Barking | North Greenwich |
	And I click Plan my Journey button
	And The journey details are displayed
	And I press Plan a Journey button
	When I press Recents tab
	Then The recent search history should be displayed