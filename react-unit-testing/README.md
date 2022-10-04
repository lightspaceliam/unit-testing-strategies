# React Unit Testing

## Structure

### Unit Testable Code

```
|	src
|		components
|           FormControls
|               Input.tsx
```

**Input.tsx**

Concrete functional component containing unit testable code.

In this context, all props require testing:

- name
- value
- label
- handleChange - you could argue this requires an integration test as it requires the parent component to test the input change 
- errorMessage
- type

### Unit Test

```
|	src
|		components
|           FormControls
|               Input.tsx
|               Input.test.tsx
```

**Input.test.tsx:**

Concrete unit tests. 

## Conventions

A popular convention with React TypeScript/JavaScript is to locate the unit testing file in the same directory as the functional file.


## Helpful Hints

**Printing the DOM:**

```ts
import { prettyDOM } from '@testing-library/react';
import Input, { InputProps } from './Input';

describe('Some description', () => {

    it('should do something', () => {
        render(
            <Input
                name={inputProps.name}
                value={inputProps.value}
                label={inputProps.label}
                handleChange={inputProps.handleChange}                   
            />
        );

        screen.debug();
        // or
        const htmlElement = screen.getByRole('textbox', { name: inputProps.label });
        console.log(prettyDOM(htmlElement));

    });
});
```

**getByRole Not Finding Expected Element:**

```ts
import { prettyDOM } from '@testing-library/react';
import Input, { InputProps } from './Input';

describe('Some description', () => {

    it('should do something', () => {
        render(
            <Input
                name={inputProps.name}
                value={inputProps.value}
                label={inputProps.label}
                handleChange={inputProps.handleChange}                   
            />
        );
        const element = screen.getByRole('textbox', { name: /Doesn'tExists/i });
        
    });
});

//  You will get message similar to:
Here are the accessible roles:

      textbox:

      Name "TestLabel":
      <input
        aria-describedby="form control testName"
        aria-invalid="false"
        class="MuiInputBase-input MuiInput-input css-1x51dt5-MuiInputBase-input-MuiInput-input"
        id="testName"
        name="testName"
        type="text"
        value="TestValue"
      />

// Update to:
const element = screen.getByRole('textbox', { name: /TestLabel/i });
```

## References

- [React Testing Library Examples](https://testing-library.com/docs/react-testing-library/example-intro)