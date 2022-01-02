import React from 'react';
import {
  BrowserRouter as Router,
  Routes,
  Route
} from "react-router-dom";
import { Flow, FlowList } from "./presentation/modules/flow";
import './App.css';

function App() {
  return (
    <Router>
        <Routes>
          <Route path="/" element={<FlowList></FlowList>} >
          </Route>
          <Route path="/flows/:id" element={<Flow></Flow>} />
        </Routes>
    </Router>
  );
}

export default App;
