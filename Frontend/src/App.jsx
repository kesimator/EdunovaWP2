import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Timovi from "./pages/timovi/Timovi"

import './App.css';

function App() {

  return (
    <>
      <NavBar />
      <Routes>
        <>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />
          <Route path={RoutesNames.TIMOVI_PREGLED} element={<Timovi />} />
        </>
      </Routes>
    </>
  )
}

export default App
