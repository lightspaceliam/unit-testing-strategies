import { styled } from '@mui/material/styles';
import InputLabel from '@mui/material/InputLabel';
import Input from '@mui/material/Input';
import red from '@mui/material/colors/red';

const white: string = 'rgb(256,256,256)';

export const StyledLabel = styled(InputLabel)({
    '&.MuiFormLabel-root': {
        color: white,
    },

    '&.MuiFormLabel-root.Mui-error': {
        color: red[700],
    },
});

export const StyledInput = styled(Input)({
    '&.MuiInputBase-root': {
        color: white,
        '&:hover': {
            '&:before': {
                borderBottom: `1px solid ${white}`,
            },
        },
        '&:before': {
            borderBottom: `1px solid ${white}`,
        }
    },
});