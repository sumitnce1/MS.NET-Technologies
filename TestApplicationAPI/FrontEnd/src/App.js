import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

function UserList() {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch('http://localhost:5299/api/Account');
        const data = await response.json();
        setUsers(data);
      } catch (error) {
        console.log('Error fetching data:', error);
      }
    }

    fetchData();
  }, []);

  return (
    <div className="bg-info pb-3 pt-2">
      <div className="container">
        <h1 className='text-center text-white'>User List</h1>
        <hr/>
        <table className="table table-striped table-hover table-bordered">
          <thead className="table-dark">
            <tr>
              <th>Name</th>
              <th>mobileNo</th>
              <th>emailId</th>
              <th>userType</th>
              <th>fatherName</th>
              <th>motherName</th>
              <th>address</th>
              <th>state</th>
              <th>city</th>
              <th>pincode</th>
              <th>courseName</th>
              <th>admissionStatus</th>
              <th>Action</th>              
            </tr>
          </thead>
          <tbody>
            {users.map((user) => (
              <tr key={user.Id}>
                <td>{user.name}</td>
                <td>{user.mobileNo}</td>
                <td>{user.emailId}</td>
                <td>{user.userType}</td>
                <td>{user.fatherName}</td>
                <td>{user.motherName}</td>
                <td>{user.address}</td>
                <td>{user.state}</td>
                <td>{user.city}</td>
                <td>{user.pincode}</td>
                <td>{user.courseName}</td>
                <td>{user.admissionStatus}</td>
                <td><a href='/Edit/{user.Id}' className='btn btn-primary btn-sm'>Edit</a>&nbsp;<a href='/Edit/{user.Id}' className='btn btn-success btn-sm'>Details</a>&nbsp; <a href='/Edit/{user.Id}' className='btn btn-danger btn-sm'>Delete</a></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default UserList;
