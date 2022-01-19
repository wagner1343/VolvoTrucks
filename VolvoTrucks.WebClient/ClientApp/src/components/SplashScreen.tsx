// React
import React from "react";

// Third party
import { Box, CircularProgress, makeStyles } from "@material-ui/core";

// Styled const
const useStyles = makeStyles((theme) => ({
  root: {
    alignItems: "center",
    backgroundColor: theme.palette.background.default,
    display: "flex",
    flexDirection: "column",
    height: "100%",
    justifyContent: "center",
    minHeight: "100%",
    padding: theme.spacing(3)
  }
}));

function SplashScreen() {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Box>
        <CircularProgress />
      </Box>
    </div>
  );
}

export default SplashScreen;
