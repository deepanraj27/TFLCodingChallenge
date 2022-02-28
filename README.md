# TFLCodingChallenge
TFLCodingChallenge Repository


I have automated 5 initial test scenarios in TFL Journey planner module as mentioned in the coding challenge.
o	5 Test scenarios are available in the “JourneyPlanner.feature” file
o	The corresponding step definitions are implementd in the “JourneyPlannerSteps.cs” file
o	Page object model file “TFLHomePage.cs” is implemented for managing the objects efficiently

	The tests are written in C sharp language using Visual Studio
	The tests are written in Gherkin syntax using Specflow extension
	The Selenium WebDriver and ChromeDriver .Net libraries are used for UI automation
	The common step of launching the browser is mentioned in the background which will be executed before each scenario.
	For clicking the ‘Done’ button for accepting cookies, Actions class methods are used
	Also for amending the journey using Edit Journey option, Action class methods are used
	The From and To locations are passed as arguments from the feature file so that modifying the test data is easy and we can also pass multiple test data’s from feature file using Examples
	The last scenario “Validation of Recents tab in the journey planner widget” is failing as the recently planned journeys via automation are not retained in the Recents tab.
