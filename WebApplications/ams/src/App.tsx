import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import './App.css';
import ComputersList from './pages/Computers/ComputersList';
import History from './pages/History/History';
import Home from './pages/Home/Home';
import IoTSetList from './pages/IoTSets/IoTSetsList';
import RoomsList from './pages/Rooms/RoomsList';
import UsersList from './pages/Users/UsersList';



const App = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact={true} component={Home} />
        <Route path="/users" exact={true} component={UsersList} />
        <Route path="/rooms" exact={true} component={RoomsList} />
        <Route path="/iot-sets" exact={true} component={IoTSetList} />
        <Route path="/computers" exact={true} component={ComputersList} />
        <Route path="/history" exact={true} component={History} />
      </Switch>
    </BrowserRouter>


  );
}

export default App;
