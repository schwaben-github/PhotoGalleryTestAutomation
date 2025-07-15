# Testing Baasic Demo Site with SpecFlow and Selenium WebDriver

### SpecFlowPhotoGallery.Specs

This repository contains UI automation tests for the Baasic Demo Site using SpecFlow, Selenium WebDriver, and NUnit on .NET 8.

### Project Structure

```
SpecFlowPhotoGallery.Specs/
├── Drivers/
│   └── WebDriverContext.cs         # WebDriver setup and teardown
├── Features/
│   └── Register.feature           # Gherkin feature file(s)
├── Pages/
│   ├── HomePage.cs                # Page Object for Home page
│   └── RegisterPage.cs            # Page Object for Register page
├── StepDefinitions/
│   ├── RegisterActionSteps.cs     # Step definitions for actions
│   └── RegisterAssertionSteps.cs  # Step definitions for assertions
├── Hooks.cs                       # SpecFlow hooks for scenario setup/teardown
├── SpecFlowPhotoGallery.Specs.csproj
└── ...
```

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Chrome browser](https://www.google.com/chrome/) (latest version recommended)
- ChromeDriver is managed automatically via NuGet

### How to Run the Tests

1. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

2. **Build the project:**
   ```sh
   dotnet build
   ```

3. **Run the tests:**
   ```sh
   dotnet test
   ```
   This will launch Chrome, maximize the window, and execute the SpecFlow scenarios.


### ...or simply use the Visual Studio Test Explorer and hotkeys

1. Open the solution in Visual Studio

2. Restore NuGet packages (right-click on the solution in Solution Explorer > Restore NuGet Packages)

3. Build the solution (`Ctrl + Shift + B`)

4. Open the Test Explorer (Test > Windows > Test Explorer) and select the test you want to run and click on "Run" button


### Notes
- The tests use SpecFlow with NUnit and Selenium WebDriver.
- The browser window is maximized automatically at the start of the scenario.
- All WebDriver setup and disposal is handled in `WebDriverContext` and `Hooks.cs`.
- Feature files are located in the `Features/` directory and step definitions in `StepDefinitions/`.
- Page Objects are in the `Pages/` directory.


### Troubleshooting
- Ensure your Chrome browser is up to date to match the ChromeDriver version.
- If you encounter issues with element selectors, check the HTML structure and update the Page Object selectors accordingly.
- For headless execution, you can modify `WebDriverContext` to add ChromeOptions with headless mode.

---

Feel free to contribute or open issues for improvements!
