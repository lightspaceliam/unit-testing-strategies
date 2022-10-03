import {
  ChangeEvent,
  FC,
  useState,
} from 'react';
import Typography from '@mui/material/Typography';
import './App.css';
import Input from './components/FormControls/Input';

interface MockFormModel {
  name: string;
}

const App: FC = (): JSX.Element => {
  const [model, setModel] = useState<MockFormModel>({ name: '' });
  const [errorMessage, setErrorMessage] = useState<string | undefined>(undefined);

  const handleInputChange = (event: ChangeEvent<HTMLInputElement>): void => {
    setModel({
      ...model,
      [event.target.name]: event.target.value
    });
  };

  return (
    <div className="App">
      <header className="App-header">
        <Typography variant='body1'>
          React Unit Testing Strategy
        </Typography>

        <Input
          name='name'
          value={model.name}
          label='Name'
          handleChange={handleInputChange}
          errorMessage={errorMessage}
        />
      </header>
    </div>
  );
}

export default App;
