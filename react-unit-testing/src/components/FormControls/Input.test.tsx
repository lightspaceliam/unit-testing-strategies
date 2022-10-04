import '@testing-library/jest-dom';
import {
    render,
    screen,
    cleanup,
} from '@testing-library/react';
import red from '@mui/material/colors/red';
import { rgbToHex } from '@mui/material'
import Input, { InputProps } from './Input';


describe('Input Unit Tests', () => {
    const inputProps: InputProps = {
        name: 'testName',
        value: 'TestValue',
        label: 'TestLabel',
        handleChange: jest.fn(),
    };

    afterEach(() => {
        cleanup();
    });

    describe('Label', () => {

        it('should render label', () => {
            render(
                <Input
                    name={inputProps.name}
                    value={inputProps.value}
                    label={inputProps.label}
                    handleChange={inputProps.handleChange}                   
                />
            );

            screen.getByText(inputProps.label, { exact: true });
        });
    });

    /**
     * Ensure all html input attributes we added as props, render. 
     */
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
            
            const htmlElement = screen.getByRole('textbox', { name: inputProps.label });

            expect(htmlElement).toBeInTheDocument();
            
            const {
                name,
                value,
                type,
            } = htmlElement as HTMLInputElement

            expect(name).toEqual(inputProps.name);
            expect(value).toEqual(inputProps.value);
            expect(type).toEqual('text');
        });

        it('should change type given type property not default', () => {
            const differentTypeInputProps: InputProps = {
                ...inputProps,
                type: 'number'
            };

            render(
                <Input
                    name={differentTypeInputProps.name}
                    value={differentTypeInputProps.value}
                    label={differentTypeInputProps.label}
                    handleChange={differentTypeInputProps.handleChange}
                    type={differentTypeInputProps.type}
                />
            );

            const htmlElement = screen.getByRole('spinbutton', { name: differentTypeInputProps.label });

            expect(htmlElement).toBeInTheDocument();
            
            const { type } = htmlElement as HTMLInputElement

            expect(type).toEqual(differentTypeInputProps.type);
        });
    });
    
    //  TODO: Test overridden styles. Default colours where updated to white.

    describe('Error messaging', () => {
        const errorInputProps: InputProps = {
            ...inputProps,
            errorMessage: 'TestErrorMessage'
        };
        
        /**
         * You could break this down or just get it done! It's a team decision.
         */
        it('should render red given error is not undefined', () => {
            render(
                <Input
                    name={errorInputProps.name}
                    value={errorInputProps.value}
                    label={errorInputProps.label}
                    handleChange={errorInputProps.handleChange}
                    errorMessage={errorInputProps.errorMessage}                   
                />
            );

            const container = document.querySelector('.MuiFormControl-root');
            expect(container).not.toBeNull();

            //  Label:
            const label = container?.querySelector('label');
            expect(label).not.toBeNull();
            const labelStyles = window.getComputedStyle(label as HTMLLabelElement);

            //  Test label for Mui error class name.
            expect(label).toHaveClass('Mui-error');

            //  Test label styled colour is as expected.
            const { color: labelColour } = labelStyles;
            expect(rgbToHex(labelColour)).toEqual(red[700]);
            
            //  Paragraph (also proves error message renders):
            const errorParagraph = screen.getByText(errorInputProps.errorMessage as string, { exact: true });

            //  Test paragraph for Mui error class name.
            expect(errorParagraph).toHaveClass('Mui-error');

            //  Test paragraph styled colour is as expected.
            const paragraphStyles = window.getComputedStyle(errorParagraph);
            const { color: paragraphColour } = labelStyles;
            expect(rgbToHex(paragraphColour)).toEqual(red[700]);
        });
    });
});