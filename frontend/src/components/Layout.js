import React from 'react';
import { Outlet } from 'react-router-dom'; 
import {Tabs } from 'antd'
import Header from './Header';
import Footer from './Footer';


export default () => {
    const items = [
        {
          key: '1',
          label: 'Home'
        },
        {
          key: '2',
          label: 'Orders'
        },
        {
          key: '3',
          label: 'About'
        },
      ];
    
  return (
          <div>
            <Header/>
            <main>
              <Outlet />
            </main>
            <Footer/>
          </div>
  );
};