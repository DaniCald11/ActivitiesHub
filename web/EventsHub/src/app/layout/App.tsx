import {Fragment, useEffect, useState} from 'react'
import { CssBaseline, ListItemText } from '@mui/material';
import { List, ListItem } from '@mui/material';
import axios from 'axios';
import NavBar from './NavBar';

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
        <List>
          {activities.map((activity: Activity) => (
            <ListItem key={activity.id}>
              <ListItemText>{activity.title}</ListItemText>
            </ListItem>
          ))}
        </List>
      
    </Fragment>
  )
}

export default App
