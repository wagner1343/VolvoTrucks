import * as React from 'react';
import { Router} from 'react-router';
import { ThemeProvider} from "@material-ui/styles";
import {SnackbarProvider} from "notistack";
import GlobalStyles from "src/components/GlobalStyles";
import ScrollReset from "src/components/ScrollReset";
import routes, {renderRoutes} from "src/routes";
import {createBrowserHistory} from "history";
import applicationTheme from "src/theme/applicationTheme";

const App = () => {
  const history = createBrowserHistory({ basename: process.env.PUBLIC_URL });
  return (
    <ThemeProvider theme={applicationTheme}>
          <SnackbarProvider dense maxSnack={3}>
            <Router history={history}>
                <GlobalStyles/>
                <ScrollReset/>
                {renderRoutes(routes)}
            </Router>
          </SnackbarProvider>
    </ThemeProvider>
  );
}

export default App;