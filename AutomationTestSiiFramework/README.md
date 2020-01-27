## Selenium Test Framework  
This project provides selenium test framework. It is written in C# and it follows best practices as well as most recent 
and top rated tools. It is designed for web test automation, to implement and run robust functional tests.  
Since everything is set up, the tests can be added and run straight away.
 
## Framework Features:
* follows page object pattern 
* parallel test execution ready
* full control by annotations
* most popular browsers preconfigured
* configurability by configuration .json file
* pretty and highly readable test result report
* easy for extension and customization
* screenshots automatically added to report (in every action and attached to Allure report)
* easily integrate with selenium grid

## Run tests from this repo

dotnet test (in your console) you need to have .NET Core on your computer
![Run Tests](.\DocumentationImages\run_tests.gif)

## Use this project 

For now, you can pull and take this project AutomationTestsSiiFramework. Put it to your repository and start using it. In the feature we will ad NuGet package and it will be easier to use in daily life.


## appsettings.json - possible to change default values

![AppSettings.json](.\DocumentationImages\appsettings.png) 

For using parameters you can change values in appsettings.json file.



## Allure Report
After run tests, you can generate a report from your tests. Allure framework generates allure-results directory where we have results from our tests. You need to go to the folder where you're run tests. After that, put below command to cmd or PowerShell:
allure serve

![Allure Report](.\DocumentationImages\allure_report.gif) 

You need to have installed Allure on your machine.
