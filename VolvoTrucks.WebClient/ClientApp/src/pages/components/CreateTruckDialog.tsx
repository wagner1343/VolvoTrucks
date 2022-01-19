import React from 'react';
import {Box, Dialog, DialogContent, DialogTitle} from "@material-ui/core";
import CreateTruckForm from "src/pages/components/CreateTruckForm";
import Truck from "src/data/Truck";

export interface CreateTruckDialogProps {
  isOpen: boolean;
  handleClose: any;
  onSubmit: any;
  onUpdate: any;
  onDelete: any;
  truck?: Truck;
  
}
function CreateTruckDialog({isOpen, handleClose, onSubmit, onDelete, onUpdate, truck}: CreateTruckDialogProps) {
  return (
    <Dialog open={isOpen} onClose={handleClose}>
      <DialogTitle>Adicionar caminhão</DialogTitle>
      <DialogContent>
        <CreateTruckForm truck={truck} onSubmit={onSubmit} onDelete={onDelete} onUpdate={onUpdate} />
        <Box mt={1} />
      </DialogContent>
    </Dialog>
  );
}

export default CreateTruckDialog;