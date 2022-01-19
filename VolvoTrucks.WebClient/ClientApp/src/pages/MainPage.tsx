import React, {useEffect, useState} from 'react';
import {Box, Button, Container, Grid, List, Typography} from "@material-ui/core";
import {useDispatch, useSelector} from "src/store";
import TruckListItem from "src/pages/components/TruckListItem";
import SplashScreen from "src/components/SplashScreen";
import {actions as truckActions} from "src/store/TrucksStore";
import CreateTruckDialog from "src/pages/components/CreateTruckDialog";
import {trucksApi} from "src/api/TrucksApi";
import {useSnackbar} from "notistack";
import Truck from "src/data/Truck";

function MainPage() {
  const dispatch = useDispatch();
  const {enqueueSnackbar} = useSnackbar()
  const {trucks, isLoading, isLoaded, errorCode} = useSelector((state) => state.trucks);
  
  useEffect(() => {
    dispatch(truckActions.list());
  }, [])

  const [selectedTruck, setSelectedTruck] = useState<Truck | undefined>();
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);

  const onSubmitTruckForm = async (values) => {
    try {
      await trucksApi.create(values);
      enqueueSnackbar("Caminhão adicionado com sucesso!", {
        variant: "success"
      })
      setIsCreateDialogOpen(false);
      dispatch(truckActions.list());
    } catch (e) {
      enqueueSnackbar("Erro inesperado ao adicionar caminhão", {
        variant: "error"
      })
    }
  }

  const onUpdateTruckForm = async (values) => {
    try {
      if(!selectedTruck) {
        return;
      }
      await trucksApi.update(selectedTruck.id, values);
      enqueueSnackbar("Caminhão atualizado com sucesso!", {
        variant: "success"
      })
      setIsCreateDialogOpen(false);
      dispatch(truckActions.list());
    } catch (e) {
      enqueueSnackbar("Erro inesperado ao atualizar caminhão", {
        variant: "error"
      })
    }
  }
  const onDeleteTruckForm = async () => {
    try {
      if(!selectedTruck) {
        return;
      }
      await trucksApi.delete(selectedTruck.id);
      enqueueSnackbar("Caminhão removido com sucesso!", {
        variant: "success"
      })
      setIsCreateDialogOpen(false);
      dispatch(truckActions.list());
    } catch (e) {
      enqueueSnackbar("Erro inesperado ao remover caminhão", {
        variant: "error"
      })
    }
  }

  const getErrorDescription = (errorCode): string => {
    switch (errorCode) {
      default:
        return "Erro desconhecido";
    }
  }
  
  const createTruckOnClick = () => {
    setSelectedTruck(undefined);
    setIsCreateDialogOpen(true);
  }
  
  const truckOnClick = (truck: Truck) => {
    setSelectedTruck(truck);
    setIsCreateDialogOpen(true);
  }

  return (
    <Container maxWidth={"sm"}>
      <CreateTruckDialog truck={selectedTruck} onUpdate={onUpdateTruckForm} onDelete={onDeleteTruckForm} isOpen={isCreateDialogOpen} handleClose={() => setIsCreateDialogOpen(false)}
                         onSubmit={onSubmitTruckForm}/>
      <Grid container>
        <Box mt={4} />
        <Grid container item xs={12} justify={"space-between"} style={{margin: 16}}>
            <Typography variant={"h4"}>Todos caminhões</Typography>
            <Button onClick={createTruckOnClick} color={"primary"} variant={"contained"}>Adicionar caminhão</Button>
        </Grid>
        {isLoaded && trucks && (
          <Grid item xs={12}>
          <List>
            {trucks.map((t) => (
                <TruckListItem
                  name={t.name}
                  modelName={t.model.name}
                  description={`${t.manufacturingYear}/${t.modelYear}`}
                  onClick={() => truckOnClick(t)}
                />
              )
            )}
          </List>
          </Grid>
        )}
        {isLoading && !isLoaded && (
          <SplashScreen/>
        )}
        {!isLoading && !isLoaded && (
          <Box>
            <Typography variant={"h6"}>Não foi possível carregar os dados</Typography>
            <Typography>{getErrorDescription(errorCode)}</Typography>
          </Box>
        )}
      </Grid>
    </Container>
  );
}

export default MainPage;