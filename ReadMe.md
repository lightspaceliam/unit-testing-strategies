# Unit Testing Strategies

Unit testing is an essential practice in software development to detect defects in the software in the early development stage to save time and cost.

### Pros & Cons

| Pro | Con |
| --- | --- |
| Better initial delivery of 1st iteration functionality | Can take longer to deliver initial result/s especially when developers are new to unit testing |
| Promotes better code and design | |
|| Not everything can be tested. For example, unit testing a data service implementing .NET's Entity Framework can be challenging as `Microsoft.EntityFrameworkCore.InMemory` does not accurately reflect or honour data annotations or referential integrity. This is just one example |
| Unit tests make it safer and easier to refactor | When a developer makes changes to unit tested code, they need to update the unit tests |
| Reduces or prevents production bugs, increases developer productivity, encourages modular programming ||
| Alerts in the form of broken unit tests when developers unintentionally break existing code when implementing new features ||
| Unit tests can be re-used in CI/CD Pipelines to prevent broken code making to production environments ||
| Self documenting | |
|  | Developers can write unit tests that prove new code works when it doesn't. This happened to me! I was writing a generic C# `DataTable` function. Due to my unfamiliarity with ADO.NET, I managed to get confused with a rows and columns. I can't remember the exact issue, only that I was able to write a broken function and unit tests that proved it worked ;-D.  |
| | Unit testing does not replace other testing types synthetic, uat, stress or penetration testing. |
## Assumptions 

When a developer writes a line of code, there is an assumption and that assumption will very in accuracy based on the experience of the developer. Every conditional statement, query, case statement, prop, ... is an assumption:

- Is my understanding of how a line of code executes is correct?
- Will the conditional `if` | `if else` | `else` work as expected?
- What happens if the data query returns no data, causes an exception, ...?
- Will the correct `switch` `case` statement work and do I need a `default` fallback?
- Will the prop passed into a component render as expected?

As mentioned above, code should be unit tested *to detect defects in the software in the early development stage to save time and cost*. 

## Proposed Structures

**.NET Core:**

```
| dotnet-unit-testing
|       Api
|       Api.Tests
|           PersonControllerTests
|               BasePersonController.cs - Reusable set up and configuration
|               FindTests.cs - concrete unit testing specific to PersonController.Find(). Inherits from BasePersonController.cs
|       EntityServices
|       EntityServices.Tests
|           PersonEntityServiceTests
|               BasePersonEntityService.cs - Reusable set up and configuration
|               FindTests.cs - concrete unit testing specific to PersonEntityService.Find() function. Inherits from BasePersonEntityService.cs
```

**React:**

```
| dotnet-unit-testing
|       src
|           App.tsx
|           components
|               FormControls
|                   Input.tsx
|                   Input.test.tsx

```

## References

- [Unit testing C# in .NET Core using dotnet test and xUnit](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)
- [Testing Library](https://testing-library.com/)
- [https://www.atlassian.com/continuous-delivery/software-testing/types-of-software-testing](https://www.atlassian.com/continuous-delivery/software-testing/types-of-software-testing)
- [Unit Testing: Advantages & Disadvantages](https://theqalead.com/test-management/unit-testing/)