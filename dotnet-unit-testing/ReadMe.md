# .NET Unit Testing

## Structure

### Unit Testable Code

```
|	DataService
|		PersonDataService.cs
|           Find({...})
|
|	Api
|		PersonController.cs
|           Find({...})
```

**PersonDataService.cs**

Concrete class containing unit testable functions.

In this context, due to the simplicity of the `PersonDataService.Find`, the assumptions requiring unit testing include:

- Simple predicate?
- Complex predicate?
- you could argue all variations of the predicate require testing...
- What happens if the predicate returns zero results?

**PersonController.cs**

Concrete class containing unit testable Api endpoints. This pattern proposes a separate test class per endpoint.

In this context, due to the simplicity of the `PersonController.Find` endpoint the two assumptions requiring unit testing include:

- Ok 200 result?
- NotFound 404 result?

### Unit Test

```
|	DataService.Tests
|		PersonDataServiceTests
|			BasePersonDataService.cs
|			FindTests.cs
|
|	Api.Tests
|		PersonControllerTests
|			BasePersonController.cs
|			FindTests.cs
```

**BasePersonDataService.cs:**

Convenience functionality written once and inherited by all {Entity}DataService test classes.

**FindTests.cs:**

Concrete unit tests. 

**BasePersonController.cs:**

Convenience functionality written once and inherited by all PersonController endpoint test classes.

**FindTests.cs:**

Concrete unit tests. 

## Conventions

TODO: write this better...

It is optimal to write atomic unit tests. In the context of:  
    - PersonDataService.Find({...}) testing single features such as:
        - What happens if the query returns empty results
        - What happens if the query returns results
        - Test different parameter combinations


[Characteristics of a good unit test](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#characteristics-of-a-good-unit-test)

## References

- [Unit testing best practices with .NET Core and .NET Standard](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices?source=recommendations)