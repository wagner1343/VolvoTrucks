import React, {useEffect, useState} from 'react';
import {Formik} from "formik";

import * as Yup from "yup";
import {
  Box,
  Button,
  Checkbox,
  FormControlLabel,
  FormHelperText,
  InputLabel, MenuItem, Select,
  TextField,
  Typography
} from "@material-ui/core";
import {ArrowBackRounded} from "@material-ui/icons";
import {truckModelsApi} from "src/api/TruckModelsApi";
import Truck from "src/data/Truck";

export interface CreateTruckFormProps {
  onSubmit: any;
  onDelete: any;
  onUpdate: any;
  truck?: Truck
}

function CreateTruckForm({onSubmit, onDelete, onUpdate, truck}: CreateTruckFormProps) {
  const [truckModels, setTruckModels] = useState()
  const [truckModelsLoadError, setTruckModelsLoadError] = useState();
  
  const loadTruckModels = async () => {
    try {
      const trucks = await truckModelsApi.list()
      setTruckModels(trucks.data);
    } catch (e) {
      setTruckModelsLoadError(e);
    }
  };

  useEffect(() => {
    loadTruckModels()
  }, [])
  
  const currentYear = new Date().getFullYear();
  
  return (
    <Formik
      enableReinitialize
      initialValues={{
        name: truck ? truck.name : "",
        modelId: truck ? truck.model.id : "",
        modelYear: truck ? truck.modelYear : "",
      }}
      validationSchema={Yup.object().shape({
        name: Yup.string().required("O nome é obrigatório"),
        modelId: Yup.number().required("O modelo é obrigatório"),
        modelYear: Yup.number()
          .oneOf([currentYear, currentYear + 1], "O ano do modelo deve ser o ano atual, ou o ano subsequente")
          .required("O ano do modelo é obrigatório"),
      })}
      onSubmit={onSubmit}
    >
      {({
          errors,
          handleChange,
          handleSubmit,
          isSubmitting,
          handleBlur,
          touched,
          values,
        isValid
        }) => {
        return (
          <form noValidate onSubmit={handleSubmit}>
            <TextField
              value={values.name}
              error={Boolean(touched.name && errors.name)}
              helperText={
                touched.name && errors.name ? errors.name : " "
              }
              InputProps={{style: {borderRadius: "8px"}}}
              onChange={handleChange}
              onBlur={handleBlur}
              name="name"
              variant="outlined"
              required
              fullWidth
              id="name"
              label="Nome"
              autoFocus
            />
            <TextField
              onBlur={handleBlur}
              required
              InputProps={{style: {borderRadius: "8px"}}}
              select
              error={Boolean(touched.modelId && errors.modelId)}
              helperText={
                touched.modelId && errors.modelId ? errors.modelId : " "
              }
              variant={"outlined"}
              disabled={!truckModels}
              id="modelId"
              name={"modelId"}
              value={values.modelId}
              label="Modelo"
              onChange={handleChange}
              fullWidth
            >
              {truckModels && truckModels.map(tm => (<MenuItem key={tm.id} value={tm.id}>{tm.name}</MenuItem>))}
            </TextField>

            <TextField
              value={values.modelYear}
              error={Boolean(touched.modelYear && errors.modelYear)}
              helperText={touched.modelYear && errors.modelYear ? errors.modelYear : " "}
              InputProps={{style: {borderRadius: "8px"}}}
              onChange={handleChange}
              onBlur={handleBlur}
              variant="outlined"
              required
              fullWidth
              id="modelYear"
              type={"number"}
              label="Ano do modelo"
              name="modelYear"
            />
            <Box style={{display: "flex", gap: "8px"}}>
              {truck && (
                <Button
                  disabled={isSubmitting}
                  onClick={() => onDelete(values)}
                  fullWidth
                  color="default"
                  disableElevation
                >
                  Excluir
                </Button>
              )}
              <div style={{flexGrow: 1}} />
              {truck ? (
                <Button
                  disabled={isSubmitting}
                  onClick={() => isValid && onUpdate(values)}
                  fullWidth
                  variant="contained"
                  color="primary"
                  disableElevation
                >
                  Salvar
                </Button>
              ) : (
                <Button
                  disabled={isSubmitting}
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                  disableElevation
                >
                  Adicionar
                </Button>
                
              )}
            </Box>
          </form>
        );
      }}
    </Formik>
  );
}

export default CreateTruckForm;