import {Fragment, useEffect, useState} from 'react'
import { Container, CssBaseline} from '@mui/material';
import axios from 'axios';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/ActivityDashboard';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/v1/events')
      .then(response => setActivities(response.data))
      .catch(error => console.error('Error fetching activities:', error));

      return () => {};

  }, []);

  return (
    <Fragment>
        <CssBaseline />
        <NavBar />
        <Container maxWidth="xl" sx={{ mt: 2 }}>  
         <ActivityDashboard activities={activities} />
        </Container>
      
    </Fragment>
  )
}

export default App
