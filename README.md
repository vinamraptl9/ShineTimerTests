🚀 ShineTimer Login Page UI Test Suite
This project contains automated UI tests using Selenium WebDriver in .NET for validating the login functionality of the Shine Timer web application.

📦 Project Structure
ShineTimerTests/
├── POMPages/               # Page Object Models
│   └── LoginPage.cs
├── Tests/                  # Test classes
│   └── ShineTimerLoginPageTest.cs
├── ExtendedCustomMethods.cs  # Custom extension methods for Selenium
🧪 Test Scenarios
Each [Fact] test validates a specific behavior on the login page:

Test Method	Description
Login_WithValidCredentials_ShouldRedirectToHomePage  |	Checks successful login and redirection to Home
Login_WithInValidCredentials_GivesCredentialsError |	Ensures proper error is shown for incorrect credentials
Login_WithEmptyCredentials_ShowsFieldRequiredErrors	| Validates required field errors for both email and password
Login_WithOnlyEmailCredentials_ShowsPasswordRequiredError	| Checks for missing password validation
Login_WithOnlyPasswordCredentials_ShowsEmailRequiredError |	Checks for missing email validation
Login_WithInvalidEmailFormat_ShowsEmailFormatError |	Verifies validation for incorrectly formatted email
Login_EmailCaseInsensitive_ShouldSucceed |	Ensures login works regardless of email casing
Login_WithWhitespaceCredentials_ShouldShowInvalidLoginError |	Tests rejection of input with only whitespace
🛠️ Technologies Used
.NET Core

xUnit for unit test execution

Selenium WebDriver for browser automation

ChromeDriver as the browser interface

Page Object Model (POM) design pattern

🔧 How to Run the Tests
Install Requirements:

.NET SDK

Chrome browser

ChromeDriver (ensure it matches your Chrome version)

Restore & Build:

bash
dotnet restore
dotnet build
Execute Tests:

bash
dotnet test
💡 Tests automatically open Chrome in maximized mode and dispose of the driver after each run.

🔍 Highlights
Follows Page Object Model for clean separation of locators and interactions.

Uses extension methods (ClickElement, EnterText) to enhance readability.

Includes waits (WebDriverWait) for proper synchronization with the DOM.

Covers both positive and negative test cases thoroughly.

🧹 Cleanup
Each test class implements IDisposable, ensuring the browser session is closed after every test to avoid memory leaks or resource contention.

📬 Feedback or Contributions
Feel free to fork, raise issues, or contribute new test cases and improvements. This suite is open for collaboration!
