//https://www.codingthesmartway.com/how-to-fetch-api-data-with-react/
// making sure that we’re able to make use of React’s useEffect and useState hook:
import React, { useState, useEffect } from 'react';

const App = () => {
  //introduce a new employee component state which will later on hold our retrieved employee sample data by using the useState hook:
  const [employees, setEmployees] = useState([])

  const FetchEmployeeData = () => {
    //If the data is retrieved successfully we’re calling setEmployees function in order to set the component user state to the data which was retrieved:
    fetch("http://localhost:5251/api/Employee").then(response => {
      return response.json()
    }).then(data => {
      setEmployees(data)
    })
  }
  //Next we need to make sure that FetchEmployeeData is executed. We want it to be executed everytime App component loads. This can be achieved by using the useEffect hook in the following way:
  useEffect(() => {
    FetchEmployeeData()
  }, [])

//iterates to the data which is stored in users state and outputs the name of each user as a list item:
/*  <div>
      {employees.length > 0  && (
        <ul>
          {employees.map(employee => (
            <li key={employee.id}>{employee.firstName} {employee.lastName} {employee.address} Tlf: {employee.phoneNumber} </li>
          ))}
        </ul>
      )}
    </div>
    */

    // https://scrimba.com/articles/react-list-array-with-map-function/
    // If you want to insert a dynamic value into the HTML you can place an expression inside curly braces:
    // <h1>Hello {name}!</h1>

    // Why not use for loops instead of map?
    // can't use for loops in JSX. This is because anything inside the curly braces in a component has to be an expression: which means you can't use imperative statements like for or if.
    // Array.map function allows us to apply the same function to every value in an array and produce a new array containing the results. Each value in the original array maps to a corresponding value in the new array.
    // Array.map method works in the same way as a mathematical function. It iterates over the array that calls the method and returns a new array, with each value from the calling array mapped to a corresponding new value, based on a mapping function.

  return (
    <div className='AnsattEllis'>
    <div className='AnsatteHeader'>
      <header>Ellis disipler - verdensherredømme neste!</header>
    </div>
    <div>
      <table id="ansatte">
        <thead>
          <tr>
            <th>Fornavn</th>
            <th>Etternavn</th>
            <th>Adresse</th>
            <th>Tlf</th>
            <th>Slette/endre</th>
          </tr>
        </thead>
        <tbody>
          {employees?.map((item) => {
            return(
              <tr key={item.id}>
                <td>{item.firstName}</td>
                <td>{item.lastName}</td>
                <td>{item.address}</td>
                <td>{item.phoneNumber}</td>
                <td>
                  <button
                    type='button'
                    className='redigerKnapp'
                    id={item.id}
                    value={item}
                    >
                    Rediger
                  </button>
                </td>
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>
    </div>
  );
}

export default App;