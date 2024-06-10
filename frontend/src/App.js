

import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/Site/Main';
import AboutPage from './pages/Site/About';
import Layout from './components/Layout';

const MyApp = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<HomePage />} />
          <Route path="about" element={<AboutPage />} />
          <Route path="main" element={<HomePage />} />
        </Route>
      </Routes>
    </Router>
  );
};

export default MyApp;