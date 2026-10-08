import {useEffect, useState} from 'react'
import { Box, Container, CssBaseline} from '@mui/material';
import axios from 'axios';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/v1/events')
      .then(response => setActivities(response.data))
      .catch(error => console.error('Error fetching activities:', error));

      return () => {};

  }, []);

  return (
    <Box sx={{ bgcolor: '#eeeeee'}}>
        <CssBaseline />
        <NavBar />
        <Container maxWidth="xl" sx={{ mt: 2 }}>  
         <ActivityDashboard activities={activities} />
        </Container>
      
    </Box>
  )
}

export default App
