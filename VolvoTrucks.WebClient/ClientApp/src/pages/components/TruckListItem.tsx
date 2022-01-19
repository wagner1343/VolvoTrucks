import React, {ReactNode} from 'react';
import {ListItem, ListItemSecondaryAction, ListItemText} from "@material-ui/core";

export interface TruckListItemProps {
  name: ReactNode;
  modelName: ReactNode;
  description: ReactNode;
  onClick: any;
}

function TruckListItem({name, modelName, description, onClick}: TruckListItemProps) {
  return (
    <ListItem button onClick={onClick}>
      <ListItemText primary={name} secondary={description}/>
      <ListItemSecondaryAction>
        {modelName}
      </ListItemSecondaryAction>
    </ListItem>
  );
}

export default TruckListItem;