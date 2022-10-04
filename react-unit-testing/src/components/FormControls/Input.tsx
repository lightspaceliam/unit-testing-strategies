import {
    FC,
    ChangeEvent
} from 'react';

import FormControl from '@mui/material/FormControl';
import FormHelperText from '@mui/material/FormHelperText';

import {
    StyledLabel,
    StyledInput,
} from './styles/input';

export interface InputProps {
    name: string;
    value: string;
    label: string;
    handleChange: (event: ChangeEvent<HTMLInputElement>) => void;
    errorMessage?: string;
    type?: string;
}

const Input: FC<InputProps> = ({
    name,
    value,
    label,
    handleChange,
    errorMessage = undefined,
    type = 'text'
}): JSX.Element => {

    const hasError = errorMessage !== undefined;
    return (
        <FormControl
            error={hasError}
            variant='standard'
            margin='dense'
        >
            <StyledLabel htmlFor={name}>{label}</StyledLabel>
            <StyledInput
                id={name}
                name={name}
                value={value}
                error={hasError}
                onChange={(event: ChangeEvent<HTMLInputElement>) => handleChange(event)}
                aria-describedby={`form control ${name}`}
                type={type}
            />
            <FormHelperText>{hasError && errorMessage}</FormHelperText>
        </FormControl>
    );
};

export default Input;