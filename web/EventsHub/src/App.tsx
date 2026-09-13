import {Fragment, useEffect, useState} from 'react'
import { ListItemText, Typography } from '@mui/material';
import { List, ListItem } from '@mui/material';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/v1/events')
      .then(response => response.json())
      .then(data => setActivities(data))
      .catch(error => console.error('Error fetching activities:', error));

      return () => {};

  }, []);

  return (
    <Fragment>
        <Typography variant="h3"> EventsHub </Typography>
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
