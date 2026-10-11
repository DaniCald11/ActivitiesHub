import {useEffect, useState} from 'react'
import { Box, Container, CssBaseline} from '@mui/material';
import axios from 'axios';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/v1/events')
      .then(response => setActivities(response.data))
      .catch(error => console.error('Error fetching activities:', error));

      return () => {};

  }, []);

  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.find(act => act.id === id));
  }

  const handleCancelSelectActivity = () => {
    setSelectedActivity(undefined);
  }

  return (
    <Box sx={{ bgcolor: '#eeeeee'}}>
        <CssBaseline />
        <NavBar />
        <Container maxWidth="xl" sx={{ mt: 2 }}>  
         <ActivityDashboard
          activities={activities}
          selectActivity={handleSelectActivity}
          cancelSelectActivity={handleCancelSelectActivity}
          selectedActivity={selectedActivity} />
        </Container>
      
    </Box>
  )
}

export default App
