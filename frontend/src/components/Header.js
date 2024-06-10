import React from 'react';
import { Outlet } from 'react-router-dom'; 
import {Tabs } from 'antd'


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
            <header>
        <div className="box-shadow" style={{paddingLeft:14,paddingTop:7, display:'flex'}}>
            <a className="header_brand" style={{paddingTop:7,float:'left',color: "#fff", alignItems: 'center'}} href="#">
            <svg xmlns="http://www.w3.org/2000/svg" style={{width:32, float:'inherit', height:32, fill:"currentColor"}}  
                         class="bi bi-box-fill" viewBox="0 0 16 18">
                        <path fill-rule="evenodd"
                              d="M15.528 2.973a.75.75 0 0 1 .472.696v8.662a.75.75 0 0 1-.472.696l-7.25 2.9a.75.75 0 0 1-.557 0l-7.25-2.9A.75.75 0 0 1 0 12.331V3.669a.75.75 0 0 1 .471-.696L7.443.184l.004-.001.274-.11a.75.75 0 0 1 .558 0l.274.11.004.001 6.971 2.789Zm-1.374.527L8 5.962 1.846 3.5 1 3.839v.4l6.5 2.6v7.922l.5.2.5-.2V6.84l6.5-2.6v-.4l-.846-.339Z" />
                    </svg>
                    <div style={{paddingBottom:5, paddingLeft:5, float:'inherit'}}>TrialFreelnce</div>
            </a>
            <div style={{float:'left', paddingLeft:30}}>
                <Tabs 
                    defaultActiveKey="1"
                    size="middle"
                    tabBarGutter={15}
                    centered
                    items={items}
                />
            </div>
            <div style={{ position:'absolute', right:10, top:35}}>
                <button onclick="location.href='/Message/UserMessages'" type="button"
                    class="btn btn-outline-light position-relative"
                    >
                    Message
                </button>
                     <a class="nav-link loggedIn-link link-light loggedIn-link">
                        Користувачі
                    </a>
                    <a class="nav-link loggedIn-link link-light loggedIn-link" style={{marginRight:40}}>
                        Рішення
                    </a>  
                                      <a href="/Account/ManageUser" class="nav-link link-light nav_user loggedIn-link">
                        <svg xmlns="http://www.w3.org/2000/svg" width="50" height="30" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                            <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                            <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                        </svg>
                            userName
                        </a>

                     <a href="Logout" 
                        class=" nav-link link-light loggedIn-link"
                        >
                        Logout
                    </a>

{/* 
                        <a class="header_link link-light">
                            Login
                        </a>
                        <a class="header_link link-light">
                            Register
                        </a> */}
             </div>
        </div>
            </header>
  );
};