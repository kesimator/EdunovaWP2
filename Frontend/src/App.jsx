import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Smjerovi from "./pages/smjerovi/Smjerovi"
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css';
import SmjeroviDodaj from "./pages/smjerovi/SmjeroviDodaj"
import SmjeroviPromijeni from "./pages/smjerovi/SmjeroviPromijeni"

import Predavaci from "./pages/predavaci/Predavaci"
import PredavaciDodaj from "./pages/predavaci/PredavaciDodaj"
import PredavaciPromijeni from "./pages/predavaci/PredavaciPromijeni"

function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />
          <Route path={RoutesNames.SMJEROVI_PREGLED} element={<Smjerovi />} />
          <Route path={RoutesNames.SMJEROVI_NOVI} element={<SmjeroviDodaj />} />
          <Route path={RoutesNames.SMJEROVI_PROMIJENI} element={<SmjeroviPromijeni />} />

          <Route path={RoutesNames.PREDAVACI_PREGLED} element={<Predavaci />} />
          <Route path={RoutesNames.PREDAVACI_NOVI} element={<PredavaciDodaj />} />
          <Route path={RoutesNames.PREDAVACI_PROMIJENI} element={<PredavaciPromijeni />} />
        </>
      </Routes>
    </>
  )
}

export default App
