# React Unit Testing Strategy

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
        const element = screen.getByRole('textbox', { name: inputProps.label });
        console.log(prettyDOM(element));
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