import React, { useEffect, useState, useCallback} from "react";
import { FormTodo } from "./FormTodo";

export const GetTodos = () => {
    const [todos, setTodos] = useState([]);

    const headers = new Headers();
    headers.append("Content-Type", "application/json");

   
    const getAll = useCallback(async function () {
        try {
            const response = await fetch('api/todos');

            if (response.status === 200) {
                const data = await response.json();
                console.log(data);
                setTodos(data);
            } else {
                console.log(response.status);
            }


        } catch (e) {
            console.log(e);
        }
    }, [todos]);

    useEffect(() => {
        getAll();
    }, []);

  

    const postTodo = useCallback(async function (todo) {
        try {
            console.log(todo);
            const options = {
                method: "POST",
                headers: headers,
                body: JSON.stringify(todo)
            };


            const response = await fetch("api/todos", options)

            if (response.status === 200) {
                alert("Agregado con exito");
                getAll();
            }
        } catch (e) {
            console.log(e);
        }

    }, [todos]);

    const deleteTodo = useCallback(async function (id) {
        try {

            const option = {
                method: "DELETE"
            }

            const response = await fetch(`api/todos/${id}`, option)

            if (response.status === 200) {
                alert("Borrado con exito");
                getAll();
            } else {
                console.log(response.status);
            }

        } catch (e) {
            console.log(e);
        }
    }, [todos]);

    const changeTodo = useCallback(async function(id) {
        try {
            const option = {
                method: "PUT"
            };

            const response = await fetch(`api/todos/status/${id}`, option);

            if (response.status === 200) {
                getAll();
            }
        } catch (e) {
            console.log(e);
        }
    });

    function handleChange(id) {
        changeTodo(id);
    }

    function handleAdd(todo){
        postTodo(todo);
    }


    function handleDelete(id) {
        deleteTodo(id);
   
    }

    function renderTable() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Actions</th>

                    </tr>
                </thead>
                <tbody>
                    {todos.map(t =>
                        <tr key={t.id}>
                            <td>{t.id}</td>
                            <td>
                                {t.isActive ? <p>{t.name}</p> : <p className="text - text-danger">{t.name}</p>}
                            </td>
                            <td>
                                <button
                                    className="btn btn-danger ms-1"
                                    onClick={function (e) {
                                        handleDelete(t.id)
                                    } }
                                >Delete</button>
                                <button
                                    className="btn btn-success ms-1"
                                    onClick={function (e) {
                                        handleChange(t.id)
                                    } }
                                   >Done</button>
                            </td>

                        </tr>
                    )}
                </tbody>
            </table>)
        
    }



    return (
        <>
            <h4>To-Dos</h4>
            <hr />
            <FormTodo onSubmit={handleAdd} />
            {todos.length > 0 && renderTable() }
            

        </>
        
        
    )

   
}