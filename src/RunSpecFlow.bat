..\tools\NUnit-2.6.3\bin\nunit-console.exe /labels /out=TestResult.txt /xml=TestResult.xml AcceptanceTesting.Specs\bin\Debug\AcceptanceTesting.Specs.dll

packages\SpecFlow.1.9.0\tools\specflow.exe nunitexecutionreport AcceptanceTesting.Specs\AcceptanceTesting.Specs.csproj /out:TestResult.html