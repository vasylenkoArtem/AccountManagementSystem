import React from 'react';
import logo from './logo.svg';
import './App.css';

const App = () => {
  return (<>
    <BrowserRouter>
      <Switch>

        <Route path="/student-details" exact={true} component={StudentDetails} />

      </Switch>
      <MainLayout />
    </BrowserRouter>
  </>
  );
}

export default App;
