import React, {useState} from 'react';
import './site_styles.css';
import {Tabs } from 'antd'

export default () => {
    const [users, setUsers] = useState([]);

    const getUsers = async () => {
        const username = 'your-username';
        const password = 'your-password';
        const basicAuthHeader = 'Basic ' + btoa(username + ':' + password);

        try {
            const response = await fetch(
                'http://localhost:5000/api/testUsers',
                {
                    method: 'GET',
                    headers: {
                        'Authorization': basicAuthHeader
                    }
                }
            );

            const responseJson = await response.json();
            setUsers(responseJson);
        } catch (error) {
            console.error('Error fetching users:', error);
        }
    };

    return (
        <div className="App">
            <button onClick={getUsers}>Загрузить список пользователей</button>
            <ul>
                {users.map((user, index) => (
                    <li key={index}>{user.name}</li> // Adjust this according to the structure of your user object
                ))}
            </ul>
        </div>
        
    );
};
