import "@testing-library/jest-dom";
import {
    render,
    screen,
    cleanup,
    prettyDOM,
} from '@testing-library/react';
// import red from '@mui/material/colors/red';
import Input, { InputProps } from './Input';


describe('Input Unit Tests', () => {
    const inputProps: InputProps = {
        name: 'testName',
        value: 'TestValue',
        label: 'TestLabel',
        handleChange: jest.fn(),
        errorMessage: undefined,
    };

    afterEach(() => {
        // inputProps.handleChange.mockClear();
        cleanup();
    });

    describe('Attributes', () => {

        it('should render defined attributes', () => {
            render(
                <Input
                    name={inputProps.name}
                    value={inputProps.value}
                    label={inputProps.label}
                    handleChange={inputProps.handleChange}                   
                />
            );
            
            const element = screen.getByRole('textbox', { name: inputProps.label });

            expect(element).toBeInTheDocument();
            console.log(prettyDOM(element));
            
            const {
                name,
                value,
                type,
            } = element as HTMLInputElement
            expect(name).toEqual(inputProps.name);
            expect(value).toEqual(inputProps.value);
            expect(type).toEqual('text');
        });
    });
    
});